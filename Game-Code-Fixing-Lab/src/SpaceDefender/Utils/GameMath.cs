using System;
using System.Drawing;

namespace SpaceDefender.Utils
{
    // ISSUE: Math helper class that's inefficient and incorrect
    public static class GameMath
    {
        // ISSUE: Constant with wrong value
        public const float PI = 3.14f; // ISSUE: Not precise enough
        
        // ISSUE: Distance calculation that's inefficient
        public static float Distance(float x1, float y1, float x2, float y2)
        {
            // ISSUE: Uses expensive Math.Sqrt unnecessarily in many cases
            float dx = x2 - x1;
            float dy = y2 - y1;
            return (float)Math.Sqrt(dx * dx + dy * dy);
        }
        
        // ISSUE: Overload with PointF that creates garbage
        public static float Distance(PointF point1, PointF point2)
        {
            // ISSUE: Duplicated calculation instead of calling other method
            float dx = point2.X - point1.X;
            float dy = point2.Y - point1.Y;
            return (float)Math.Sqrt(dx * dx + dy * dy);
        }
        
        // ISSUE: Distance squared method that's not used where it should be
        public static float DistanceSquared(float x1, float y1, float x2, float y2)
        {
            float dx = x2 - x1;
            float dy = y2 - y1;
            return dx * dx + dy * dy;
        }
        
        // ISSUE: Angle calculation with wrong return type
        public static float AngleBetween(float x1, float y1, float x2, float y2)
        {
            // ISSUE: Returns radians but name suggests degrees
            return (float)Math.Atan2(y2 - y1, x2 - x1);
        }
        
        // ISSUE: Degrees to radians with wrong constant
        public static float DegreesToRadians(float degrees)
        {
            return degrees * (PI / 180.0f); // ISSUE: Uses wrong PI value
        }
        
        // ISSUE: Radians to degrees with wrong constant
        public static float RadiansToDegrees(float radians)
        {
            return radians * (180.0f / PI); // ISSUE: Uses wrong PI value
        }
        
        // ISSUE: Clamp method that doesn't handle edge cases
        public static float Clamp(float value, float min, float max)
        {
            // ISSUE: No validation - what if min > max?
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }
        
        // ISSUE: Lerp method with potential issues
        public static float Lerp(float start, float end, float t)
        {
            // ISSUE: No clamping of t parameter
            return start + (end - start) * t;
        }
        
        // ISSUE: Normalize method that can cause division by zero
        public static PointF Normalize(PointF vector)
        {
            float length = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            // ISSUE: No check for zero length
            return new PointF(vector.X / length, vector.Y / length);
        }
        
        // ISSUE: Rectangle collision that's inefficient
        public static bool RectangleCollision(Rectangle rect1, Rectangle rect2)
        {
            // ISSUE: Uses .NET Rectangle.IntersectsWith but wraps it unnecessarily
            return rect1.IntersectsWith(rect2);
        }
        
        // ISSUE: Circle collision that's inefficient for most use cases
        public static bool CircleCollision(float x1, float y1, float radius1, float x2, float y2, float radius2)
        {
            // ISSUE: Uses Distance method which includes expensive sqrt
            float distance = Distance(x1, y1, x2, y2);
            return distance < (radius1 + radius2);
        }
        
        // ISSUE: Point in rectangle check that already exists in .NET
        public static bool PointInRectangle(float x, float y, Rectangle rect)
        {
            // ISSUE: Reimplements .NET functionality poorly
            return x >= rect.X && x <= rect.X + rect.Width &&
                   y >= rect.Y && y <= rect.Y + rect.Height;
        }
        
        // ISSUE: Random point generation that's not really random
        public static PointF RandomPointInRectangle(Rectangle bounds)
        {
            // ISSUE: Creates new Random each time - terrible for randomness
            Random rand = new Random();
            float x = rand.Next(bounds.X, bounds.X + bounds.Width);
            float y = rand.Next(bounds.Y, bounds.Y + bounds.Height);
            return new PointF(x, y);
        }
        
        // ISSUE: Move towards method that doesn't handle overshooting
        public static PointF MoveTowards(PointF current, PointF target, float speed)
        {
            PointF direction = Normalize(new PointF(target.X - current.X, target.Y - current.Y));
            // ISSUE: Can overshoot target
            return new PointF(current.X + direction.X * speed, current.Y + direction.Y * speed);
        }
    }
}
