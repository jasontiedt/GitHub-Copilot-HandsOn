using System;
using System.Drawing;

namespace SpaceDefender.Entities
{
    // ISSUE: Almost identical to Player class - code duplication
    // ISSUE: No inheritance or composition pattern
    public class Enemy
    {
        // ISSUE: Public fields again - terrible encapsulation
        public float X;
        public float Y;
        public int Width;
        public int Height;
        public int Health;
        public float Speed;
        public string Type; // ISSUE: String for type - should be enum
        
        // ISSUE: Random instance per enemy - performance killer
        private Random random = new Random();
        
        // ISSUE: Constructor with no validation
        public Enemy(float x, float y)
        {
            this.X = x;
            this.Y = y;
            this.Width = 40; // ISSUE: Hardcoded again
            this.Height = 30;
            this.Health = 50;
            this.Speed = 2.0f;
            this.Type = "Basic"; // ISSUE: Magic string
        }
        
        // ISSUE: Another constructor with different hardcoded values
        public Enemy(float x, float y, string type)
        {
            this.X = x;
            this.Y = y;
            this.Type = type;
            
            // ISSUE: Switch on string - inefficient and error-prone
            switch (type)
            {
                case "Basic":
                    this.Width = 40;
                    this.Height = 30;
                    this.Health = 50;
                    this.Speed = 2.0f;
                    break;
                case "Fast":
                    this.Width = 30;
                    this.Height = 25;
                    this.Health = 30;
                    this.Speed = 4.0f;
                    break;
                case "Heavy":
                    this.Width = 60;
                    this.Height = 40;
                    this.Health = 100;
                    this.Speed = 1.0f;
                    break;
                default:
                    // ISSUE: Default case with hardcoded values
                    this.Width = 40;
                    this.Height = 30;
                    this.Health = 50;
                    this.Speed = 2.0f;
                    break;
            }
        }
        
        // ISSUE: Update method with hardcoded behavior
        public void Update()
        {
            // ISSUE: Only moves down - not interesting gameplay
            this.Y += this.Speed;
            
            // ISSUE: Random movement sometimes - inconsistent behavior
            if (this.random.Next(100) < 5) // 5% chance
            {
                this.X += this.random.Next(-20, 21); // ISSUE: Can move off screen
            }
        }
        
        // ISSUE: Damage method with no validation
        public void TakeDamage(int damage)
        {
            this.Health -= damage;
            // ISSUE: No death state handling
            // ISSUE: Health can go negative
        }
        
        // ISSUE: Copy-paste from Player class
        public bool CollidesWith(Player player)
        {
            // ISSUE: No null check
            return this.X < player.X + player.Width &&
                   this.X + this.Width > player.X &&
                   this.Y < player.Y + player.Height &&
                   this.Y + this.Height > player.Y;
        }
        
        // ISSUE: More copy-paste collision detection
        public bool CollidesWith(Bullet bullet)
        {
            // ISSUE: No null check
            return this.X < bullet.X + bullet.Width &&
                   this.X + this.Width > bullet.X &&
                   this.Y < bullet.Y + bullet.Height &&
                   this.Y + this.Height > bullet.Y;
        }
        
        // ISSUE: Drawing logic in entity - wrong place
        public void Draw(Graphics g)
        {
            // ISSUE: Different colors based on string comparison - inefficient
            Brush enemyBrush;
            switch (this.Type)
            {
                case "Basic":
                    enemyBrush = Brushes.Red;
                    break;
                case "Fast":
                    enemyBrush = Brushes.Orange;
                    break;
                case "Heavy":
                    enemyBrush = Brushes.DarkRed;
                    break;
                default:
                    enemyBrush = Brushes.Red;
                    break;
            }
            
            // ISSUE: No error handling
            g.FillRectangle(enemyBrush, this.X, this.Y, this.Width, this.Height);
        }
        
        // ISSUE: Duplicate from Player
        public bool IsAlive()
        {
            return this.Health > 0;
        }
        
        // ISSUE: Off-screen check hardcoded to specific screen size
        public bool IsOffScreen()
        {
            return this.Y > 600; // ISSUE: Magic number
        }
        
        // ISSUE: Another duplicate method
        public Rectangle GetBounds()
        {
            return new Rectangle((int)this.X, (int)this.Y, this.Width, this.Height);
        }
        
        // ISSUE: AI method that doesn't do anything intelligent
        public void UpdateAI()
        {
            // ISSUE: "AI" that just moves randomly sometimes
            if (this.random.Next(1000) < 10) // 1% chance
            {
                this.Speed += 0.1f; // ISSUE: Speed increases forever
            }
        }
    }
}
