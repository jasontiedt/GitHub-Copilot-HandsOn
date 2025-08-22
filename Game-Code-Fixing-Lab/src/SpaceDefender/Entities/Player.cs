using System;
using System.Drawing;

namespace SpaceDefender.Entities
{
    // ISSUE: No base class or interface - code duplication ahead
    // ISSUE: Public fields everywhere - no encapsulation
    // ISSUE: No validation or error handling
    public class Player
    {
        // ISSUE: Public fields break encapsulation
        public float X;
        public float Y;
        public int Width;
        public int Height;
        public int Health;
        public int MaxHealth;
        
        // ISSUE: No proper initialization
        // ISSUE: Magic numbers hardcoded
        public Player()
        {
            this.X = 400; // ISSUE: Assumes screen width
            this.Y = 500; // ISSUE: Assumes screen height
            this.Width = 50;
            this.Height = 30;
            this.Health = 100;
            this.MaxHealth = 100;
        }
        
        // ISSUE: Constructor with parameters has no validation
        public Player(float x, float y)
        {
            this.X = x;
            this.Y = y;
            this.Width = 50; // ISSUE: Still hardcoded
            this.Height = 30;
            this.Health = 100;
            this.MaxHealth = 100;
        }
        
        // ISSUE: No boundary checking in movement
        public void MoveLeft()
        {
            this.X -= 10; // ISSUE: Can go off screen
        }
        
        public void MoveRight()
        {
            this.X += 10; // ISSUE: Can go off screen
        }
        
        public void MoveUp()
        {
            this.Y -= 10; // ISSUE: Can go off screen
        }
        
        public void MoveDown()
        {
            this.Y += 10; // ISSUE: Can go off screen
        }
        
        // ISSUE: No validation for damage amount
        public void TakeDamage(int damage)
        {
            this.Health -= damage;
            // ISSUE: Health can go negative
            // ISSUE: No death handling
        }
        
        // ISSUE: Primitive collision detection
        public bool CollidesWith(Enemy enemy)
        {
            // ISSUE: What if enemy is null?
            return this.X < enemy.X + enemy.Width &&
                   this.X + this.Width > enemy.X &&
                   this.Y < enemy.Y + enemy.Height &&
                   this.Y + this.Height > enemy.Y;
        }
        
        // ISSUE: Drawing logic in entity class - breaks separation of concerns
        public void Draw(Graphics g)
        {
            // ISSUE: No error handling for drawing
            // ISSUE: Hardcoded color
            g.FillRectangle(Brushes.Blue, this.X, this.Y, this.Width, this.Height);
        }
        
        // ISSUE: No proper state management
        public bool IsAlive()
        {
            return this.Health > 0;
        }
        
        // ISSUE: No proper bounds checking
        public Rectangle GetBounds()
        {
            return new Rectangle((int)this.X, (int)this.Y, this.Width, this.Height);
        }
    }
}
