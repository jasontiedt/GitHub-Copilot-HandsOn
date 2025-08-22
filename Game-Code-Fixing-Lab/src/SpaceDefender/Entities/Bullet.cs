using System;
using System.Drawing;

namespace SpaceDefender.Entities
{
    // ISSUE: Yet another class with public fields and duplicated code
    public class Bullet
    {
        // ISSUE: More public fields - no encapsulation anywhere
        public float X;
        public float Y;
        public int Width;
        public int Height;
        public float Speed;
        public string Owner; // ISSUE: String for owner - should be enum or proper type
        
        // ISSUE: Constructor with hardcoded values
        public Bullet(float x, float y)
        {
            this.X = x;
            this.Y = y;
            this.Width = 5; // ISSUE: Hardcoded bullet size
            this.Height = 10;
            this.Speed = 10.0f; // ISSUE: Hardcoded speed
            this.Owner = "Player"; // ISSUE: Default to player
        }
        
        // ISSUE: Constructor with owner but still hardcoded values
        public Bullet(float x, float y, string owner)
        {
            this.X = x;
            this.Y = y;
            this.Owner = owner;
            
            // ISSUE: Different bullet properties based on string comparison
            if (owner == "Player")
            {
                this.Width = 5;
                this.Height = 10;
                this.Speed = 10.0f;
            }
            else if (owner == "Enemy")
            {
                this.Width = 8; // ISSUE: Enemy bullets bigger for some reason
                this.Height = 12;
                this.Speed = 5.0f; // ISSUE: Slower than player bullets
            }
            else
            {
                // ISSUE: Default case with random values
                this.Width = 5;
                this.Height = 10;
                this.Speed = 8.0f;
            }
        }
        
        // ISSUE: Update method assumes bullets only move vertically
        public void Update()
        {
            // ISSUE: Direction based on string comparison - terrible performance
            if (this.Owner == "Player")
            {
                this.Y -= this.Speed; // Player bullets go up
            }
            else if (this.Owner == "Enemy")
            {
                this.Y += this.Speed; // Enemy bullets go down
            }
            else
            {
                // ISSUE: Unknown owner bullets just disappear
                this.Y -= this.Speed;
            }
        }
        
        // ISSUE: More duplicate collision detection code
        public bool CollidesWith(Player player)
        {
            // ISSUE: No null check
            // ISSUE: Only check if this is enemy bullet?
            if (this.Owner != "Enemy") return false;
            
            return this.X < player.X + player.Width &&
                   this.X + this.Width > player.X &&
                   this.Y < player.Y + player.Height &&
                   this.Y + this.Height > player.Y;
        }
        
        // ISSUE: Another duplicate collision method
        public bool CollidesWith(Enemy enemy)
        {
            // ISSUE: No null check
            // ISSUE: Only check if this is player bullet?
            if (this.Owner != "Player") return false;
            
            return this.X < enemy.X + enemy.Width &&
                   this.X + this.Width > enemy.X &&
                   this.Y < enemy.Y + enemy.Height &&
                   this.Y + this.Height > enemy.Y;
        }
        
        // ISSUE: Off-screen check with hardcoded screen dimensions
        public bool IsOffScreen()
        {
            return this.Y < 0 || this.Y > 600 || this.X < 0 || this.X > 800; // ISSUE: Magic numbers
        }
        
        // ISSUE: Drawing logic in entity again
        public void Draw(Graphics g)
        {
            // ISSUE: Color based on string comparison
            Brush bulletBrush;
            if (this.Owner == "Player")
            {
                bulletBrush = Brushes.Yellow;
            }
            else if (this.Owner == "Enemy")
            {
                bulletBrush = Brushes.Red;
            }
            else
            {
                bulletBrush = Brushes.White; // ISSUE: Default color
            }
            
            // ISSUE: No error handling for drawing
            g.FillRectangle(bulletBrush, this.X, this.Y, this.Width, this.Height);
        }
        
        // ISSUE: Another duplicate bounds method
        public Rectangle GetBounds()
        {
            return new Rectangle((int)this.X, (int)this.Y, this.Width, this.Height);
        }
        
        // ISSUE: Method that checks if bullet should be removed
        public bool ShouldRemove()
        {
            return this.IsOffScreen();
        }
    }
}
