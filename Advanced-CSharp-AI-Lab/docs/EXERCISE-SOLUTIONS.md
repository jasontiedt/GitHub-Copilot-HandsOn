# Advanced C# AI Lab - Exercise Solutions

This document provides guidance and example implementations for the Advanced C# AI Lab challenges. Use these as reference implementations after attempting the challenges yourself.

## 🎯 Exercise 1: CQRS + Event Sourcing Architecture (🔴 Expert)

### AI Prompting Strategy
```
"Help me implement a CQRS architecture with event sourcing for a workflow management system. I need:
1. Command handlers that process workflow commands
2. Event store for persisting domain events
3. Event-driven projections for read models
4. Distributed coordination across multiple workflow instances"
```

### Key Implementation Points

#### Command Handler Implementation
```csharp
public class WorkflowCommandHandler : ICommandHandler<CreateWorkflowCommand>
{
    private readonly IEventStore _eventStore;
    private readonly IWorkflowRepository _repository;
    
    public async ValueTask HandleAsync(CreateWorkflowCommand command, CancellationToken cancellationToken)
    {
        // Load aggregate from event store
        var workflow = await _repository.GetByIdAsync(command.WorkflowId);
        
        // Execute business logic
        workflow.CreateWorkflow(command.Name, command.Definition);
        
        // Persist events
        await _eventStore.SaveEventsAsync(workflow.UncommittedEvents, workflow.Version);
        workflow.MarkEventsAsCommitted();
    }
}
```

#### Event Store Pattern
```csharp
public class EventStore : IEventStore
{
    public async Task SaveEventsAsync(IEnumerable<IDomainEvent> events, int expectedVersion)
    {
        // Implement optimistic concurrency control
        // Serialize events as JSON
        // Store in append-only fashion
    }
    
    public async Task<IEnumerable<IDomainEvent>> GetEventsAsync(Guid aggregateId)
    {
        // Load events from storage
        // Deserialize and return in order
    }
}
```

### Performance Targets
- Process 10,000 commands/second
- Event sourcing with sub-10ms write latency
- Read model consistency within 100ms

---

## 🎯 Exercise 2: High-Performance Async Patterns (🔴 Expert)

### AI Prompting Strategy
```
"I need to implement high-performance async patterns in C# including:
1. Lock-free data structures using Interlocked operations
2. Custom TaskScheduler optimized for CPU-intensive work
3. Memory-efficient async operations with minimal allocations
4. Object pooling for high-throughput scenarios"
```

### Lock-Free Queue Implementation
```csharp
public class LockFreeQueue<T> : IProducerConsumerCollection<T>
{
    private volatile Node _head;
    private volatile Node _tail;
    
    private class Node
    {
        public volatile T Data;
        public volatile Node Next;
    }
    
    public bool TryEnqueue(T item)
    {
        var newNode = new Node { Data = item };
        while (true)
        {
            var tail = _tail;
            var next = tail.Next;
            
            if (tail == _tail) // Consistency check
            {
                if (next == null)
                {
                    if (Interlocked.CompareExchange(ref tail.Next, newNode, null) == null)
                    {
                        Interlocked.CompareExchange(ref _tail, newNode, tail);
                        return true;
                    }
                }
                else
                {
                    Interlocked.CompareExchange(ref _tail, next, tail);
                }
            }
        }
    }
}
```

### Custom TaskScheduler
```csharp
public class WorkflowTaskScheduler : TaskScheduler, IDisposable
{
    private readonly Thread[] _threads;
    private readonly LockFreeQueue<Task> _taskQueue;
    
    protected override void QueueTask(Task task)
    {
        _taskQueue.TryEnqueue(task);
        // Signal worker threads
    }
    
    private void WorkerLoop()
    {
        while (!_cancellationToken.IsCancellationRequested)
        {
            if (_taskQueue.TryDequeue(out var task))
            {
                TryExecuteTask(task);
            }
            else
            {
                Thread.Yield(); // Cooperative yielding
            }
        }
    }
}
```

---

## 🎯 Exercise 3: Message-Driven Architecture (🔴 Expert)

### AI Prompting Strategy
```
"Help me implement a message-driven architecture with:
1. High-throughput in-process message bus (50k+ messages/sec)
2. Saga pattern for distributed transaction coordination
3. Circuit breaker for resilience
4. Backpressure handling to prevent system overload"
```

### High-Performance Message Bus
```csharp
public class InProcessMessageBus : IMessageBus
{
    private readonly ConcurrentDictionary<Type, List<IMessageHandler>> _handlers = new();
    private readonly Channel<BaseMessage> _messageChannel;
    
    public InProcessMessageBus()
    {
        var options = new BoundedChannelOptions(10000)
        {
            FullMode = BoundedChannelFullMode.Wait,
            SingleReader = false,
            SingleWriter = false
        };
        _messageChannel = Channel.CreateBounded<BaseMessage>(options);
        
        StartProcessingLoop();
    }
    
    public async ValueTask PublishAsync<T>(T message) where T : BaseMessage
    {
        await _messageChannel.Writer.WriteAsync(message);
    }
    
    private async Task StartProcessingLoop()
    {
        await foreach (var message in _messageChannel.Reader.ReadAllAsync())
        {
            await ProcessMessageAsync(message);
        }
    }
}
```

### Saga Coordinator Pattern
```csharp
public abstract class SagaCoordinator<TState> where TState : new()
{
    protected TState State { get; private set; } = new();
    public SagaStatus Status { get; private set; } = SagaStatus.NotStarted;
    
    public async ValueTask StartAsync()
    {
        Status = SagaStatus.Running;
        var steps = await DefineStepsAsync();
        
        foreach (var step in steps)
        {
            try
            {
                await ExecuteStepAsync(step);
            }
            catch (Exception ex)
            {
                if (await ShouldCompensateAsync(ex))
                {
                    await CompensateAsync();
                    Status = SagaStatus.Compensated;
                    return;
                }
                throw;
            }
        }
        
        Status = SagaStatus.Completed;
    }
    
    protected abstract ValueTask<SagaStep[]> DefineStepsAsync();
    protected abstract ValueTask<bool> ShouldCompensateAsync(Exception exception);
}
```

---

## 🎯 Exercise 4: Security & Compliance (🔴 Expert)

### AI Prompting Strategy
```
"I need to implement enterprise security features:
1. AES-256 encryption with secure key management
2. Input validation preventing SQL injection and XSS
3. JWT authentication with proper token validation
4. GDPR compliance with data export and erasure"
```

### Data Encryption Service
```csharp
public class DataEncryptionService
{
    private readonly IKeyManagementService _keyService;
    
    public async ValueTask<EncryptedData> EncryptAsync(string data)
    {
        using var aes = Aes.Create();
        aes.KeySize = 256;
        aes.GenerateKey();
        aes.GenerateIV();
        
        // Store key securely
        var keyId = await _keyService.StoreKeyAsync(aes.Key);
        
        using var encryptor = aes.CreateEncryptor();
        var dataBytes = Encoding.UTF8.GetBytes(data);
        var encrypted = encryptor.TransformFinalBlock(dataBytes, 0, dataBytes.Length);
        
        return new EncryptedData(
            Convert.ToBase64String(encrypted),
            Convert.ToBase64String(aes.IV),
            keyId
        );
    }
    
    public async ValueTask<string> DecryptAsync(EncryptedData encryptedData)
    {
        var key = await _keyService.RetrieveKeyAsync(encryptedData.KeyId);
        
        using var aes = Aes.Create();
        aes.Key = key;
        aes.IV = Convert.FromBase64String(encryptedData.InitializationVector);
        
        using var decryptor = aes.CreateDecryptor();
        var encryptedBytes = Convert.FromBase64String(encryptedData.EncryptedValue);
        var decrypted = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
        
        return Encoding.UTF8.GetString(decrypted);
    }
}
```

### Input Validation Service
```csharp
public class InputValidator
{
    private static readonly Regex SqlInjectionPattern = new(@"(\b(ALTER|CREATE|DELETE|DROP|EXEC(UTE){0,1}|INSERT( +INTO){0,1}|MERGE|SELECT|UPDATE|UNION( +ALL){0,1})\b)", RegexOptions.IgnoreCase);
    private static readonly Regex XssPattern = new(@"<script\b[^<]*(?:(?!<\/script>)<[^<]*)*<\/script>", RegexOptions.IgnoreCase);
    
    public async ValueTask<ValidationResult> ValidateAsync(string input, ValidationRule rule)
    {
        var errors = new List<string>();
        var sanitizedValue = input;
        
        switch (rule)
        {
            case ValidationRule.NoSqlInjection:
                if (SqlInjectionPattern.IsMatch(input))
                {
                    errors.Add("Input contains potential SQL injection patterns");
                }
                break;
                
            case ValidationRule.NoXss:
                if (XssPattern.IsMatch(input))
                {
                    errors.Add("Input contains potentially malicious script content");
                }
                sanitizedValue = HtmlEncoder.Default.Encode(input);
                break;
                
            case ValidationRule.EmailFormat:
                if (!MailAddress.TryCreate(input, out _))
                {
                    errors.Add("Invalid email format");
                }
                break;
        }
        
        return new ValidationResult(errors.Count == 0, sanitizedValue, errors.ToArray());
    }
}
```

---

## 🎯 Exercise 5: Observability & Monitoring (🔴 Expert)

### AI Prompting Strategy
```
"Help me implement comprehensive observability:
1. OpenTelemetry distributed tracing with correlation
2. Structured logging with rich context
3. Business metrics and SLA tracking
4. Health checks and alerting system"
```

### Distributed Tracing Implementation
```csharp
public class DistributedTracingService
{
    private static readonly ActivitySource ActivitySource = new("CloudFlow.Core");
    
    public TracingActivity StartActivity(string operationName, Guid correlationId)
    {
        var activity = ActivitySource.StartActivity(operationName);
        activity?.SetTag("correlation.id", correlationId.ToString());
        
        return new TracingActivity
        {
            OperationName = operationName,
            CorrelationId = correlationId,
            InternalActivity = activity
        };
    }
    
    public TraceContext GetCurrentTraceContext()
    {
        var activity = Activity.Current;
        if (activity == null) return null;
        
        return new TraceContext(
            activity.TraceId.ToString(),
            activity.SpanId.ToString(),
            Guid.Parse(activity.GetTagItem("correlation.id")?.ToString() ?? Guid.Empty.ToString())
        );
    }
}
```

### Structured Logging with Correlation
```csharp
public class StructuredLogger
{
    private readonly ILogger _logger;
    private static readonly AsyncLocal<Dictionary<string, object>> _context = new();
    
    public IDisposable BeginScope(Dictionary<string, object> context)
    {
        var previousContext = _context.Value;
        _context.Value = context;
        
        return new LoggingScope(() => _context.Value = previousContext);
    }
    
    public void LogInformation(string message, object data)
    {
        var enrichedData = EnrichWithContext(data);
        _logger.LogInformation("{Message} {Data}", message, enrichedData);
    }
    
    private object EnrichWithContext(object data)
    {
        var context = _context.Value ?? new Dictionary<string, object>();
        var properties = data.GetType().GetProperties().ToDictionary(p => p.Name, p => p.GetValue(data));
        
        return context.Concat(properties).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
    }
}
```

---

## 🎯 Exercise 6: Performance Optimization (🔴 Expert)

### AI Prompting Strategy
```
"I need to optimize C# performance for high-throughput scenarios:
1. Memory allocation optimization with object pooling
2. Span<T> and Memory<T> for zero-copy operations
3. SIMD vectorization for data processing
4. Lock-free algorithms for concurrent scenarios"
```

### High-Performance Object Pool
```csharp
public class WorkflowObjectPool<T> : IDisposable where T : class, new()
{
    private readonly ConcurrentQueue<T> _objects = new();
    private readonly Func<T> _objectGenerator;
    private readonly Action<T> _resetAction;
    private int _currentCount;
    private readonly int _maxSize;
    
    public WorkflowObjectPool(int maxSize, Func<T> objectGenerator = null, Action<T> resetAction = null)
    {
        _maxSize = maxSize;
        _objectGenerator = objectGenerator ?? (() => new T());
        _resetAction = resetAction ?? (_ => { });
    }
    
    public T Get()
    {
        if (_objects.TryDequeue(out T item))
        {
            Interlocked.Decrement(ref _currentCount);
            return item;
        }
        
        return _objectGenerator();
    }
    
    public void Return(T item)
    {
        if (Interlocked.Read(ref _currentCount) < _maxSize)
        {
            _resetAction(item);
            _objects.Enqueue(item);
            Interlocked.Increment(ref _currentCount);
        }
    }
}
```

### SIMD-Optimized Data Processing
```csharp
public static class SimdDataProcessor
{
    public static void ProcessWorkflowMetrics(ReadOnlySpan<float> input, Span<float> output)
    {
        if (Vector.IsHardwareAccelerated && input.Length >= Vector<float>.Count)
        {
            ProcessWithSimd(input, output);
        }
        else
        {
            ProcessScalar(input, output);
        }
    }
    
    private static void ProcessWithSimd(ReadOnlySpan<float> input, Span<float> output)
    {
        var vectorSize = Vector<float>.Count;
        var length = input.Length - (input.Length % vectorSize);
        
        for (int i = 0; i < length; i += vectorSize)
        {
            var vector = new Vector<float>(input.Slice(i));
            var processed = Vector.Multiply(vector, new Vector<float>(2.0f)); // Example processing
            processed.CopyTo(output.Slice(i));
        }
        
        // Handle remaining elements
        for (int i = length; i < input.Length; i++)
        {
            output[i] = input[i] * 2.0f;
        }
    }
}
```

## 🔧 Performance Benchmarking

Use BenchmarkDotNet to validate your implementations:

```csharp
[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net80)]
public class PerformanceBenchmarks
{
    [Benchmark]
    public async Task CqrsCommandProcessing()
    {
        var handler = new WorkflowCommandHandler();
        var command = new CreateWorkflowCommand();
        await handler.HandleAsync(command, CancellationToken.None);
    }
    
    [Benchmark]
    public void LockFreeQueueOperations()
    {
        var queue = new LockFreeQueue<string>();
        queue.TryEnqueue("test");
        queue.TryDequeue(out _);
    }
}
```

## 📊 Success Metrics

- **CQRS Architecture**: 10,000+ commands/second throughput
- **Lock-Free Data Structures**: Zero lock contention under load
- **Message Bus**: 50,000+ messages/second processing
- **Security**: All OWASP top 10 vulnerabilities addressed
- **Observability**: <1% performance overhead for instrumentation
- **Performance**: <10ms P95 latency for critical operations

## 🎯 Next Steps

1. **Extend the Challenges**: Add more complex scenarios
2. **Integration Testing**: Test components working together
3. **Load Testing**: Validate performance under realistic load
4. **Security Auditing**: Perform penetration testing
5. **Production Readiness**: Add monitoring and alerting

Remember: These are expert-level challenges. Take your time, use AI assistance liberally, and focus on understanding the underlying patterns and principles. The goal is to build production-ready, enterprise-grade C# applications.
