using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SpaceDefender.Game
{
    // ISSUE: This class violates Single Responsibility Principle - it does EVERYTHING!
    // ISSUE: No error handling, memory leaks, performance problems
    public class GameEngine : Form
    {
        // ISSUE: Public fields instead of properties - breaks encapsulation
        public List<object> gameObjects;
        public List<object> enemies;
        public List<object> bullets;
        public object player;
        public int score;
        public bool isGameRunning;
        
        // ISSUE: Timer is never disposed - memory leak
        private Timer gameTimer;
        
        // ISSUE: Graphics objects not disposed - memory leak
        private Graphics g;
        private Bitmap backBuffer;
        
        // ISSUE: Hardcoded values everywhere
        private int SCREEN_WIDTH = 800;
        private int SCREEN_HEIGHT = 600;
        private int GAME_SPEED = 16; // Should be 60 FPS but this is wrong calculation
        
        // ISSUE: Constructor does too much work
        public GameEngine()
        {
            // ISSUE: No null checking
            this.gameObjects = new List<object>();
            this.enemies = new List<object>();
            this.bullets = new List<object>();
            
            // ISSUE: Exception prone - what if this fails?
            this.SetupWindow();
            this.InitializeGame();
            this.StartGameLoop();
        }
        
        // ISSUE: Method name doesn't match what it does
        private void SetupWindow()
        {
            // ISSUE: Magic numbers everywhere
            this.Size = new Size(800, 600);
            this.Text = "Space Defender - BROKEN VERSION";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            
            // ISSUE: No error handling for graphics creation
            this.backBuffer = new Bitmap(800, 600);
            this.g = Graphics.FromImage(backBuffer);
            
            // ISSUE: Events not properly unsubscribed - memory leak potential
            this.Paint += GameEngine_Paint;
            this.KeyDown += GameEngine_KeyDown;
            this.KeyUp += GameEngine_KeyUp;
        }
        
        // ISSUE: Method does way too much
        private void InitializeGame()
        {
            // ISSUE: Hardcoded player creation - not extensible
            // ISSUE: What if player creation fails?
            this.player = new { X = 400, Y = 500, Width = 50, Height = 30, Health = 100 };
            
            // ISSUE: Magic numbers for enemy spawning
            for (int i = 0; i < 5; i++)
            {
                // ISSUE: Anonymous objects are hard to work with and error-prone
                var enemy = new { 
                    X = i * 150 + 50, 
                    Y = 50, 
                    Width = 40, 
                    Height = 30, 
                    Health = 50,
                    Speed = 2
                };
                this.enemies.Add(enemy);
            }
            
            this.score = 0;
            this.isGameRunning = true;
        }
        
        // ISSUE: Timer not configured properly
        private void StartGameLoop()
        {
            this.gameTimer = new Timer();
            this.gameTimer.Interval = GAME_SPEED; // Wrong! This is not 60 FPS
            this.gameTimer.Tick += GameLoop;
            this.gameTimer.Start();
        }
        
        // ISSUE: Massive method that does everything - God method anti-pattern
        private void GameLoop(object sender, EventArgs e)
        {
            // ISSUE: No error handling - if anything fails, game crashes
            this.UpdateGame();
            this.CheckCollisions();
            this.RemoveDeadObjects();
            this.SpawnEnemies();
            this.Invalidate(); // Force repaint
        }
        
        // ISSUE: Inefficient update loop - O(n) for each type
        private void UpdateGame()
        {
            // ISSUE: Null reference potential
            // ISSUE: Casting everywhere - performance hit and type unsafe
            dynamic playerObj = (dynamic)this.player;
            
            // ISSUE: No boundary checking - player can move off screen
            // Movement logic missing here - where is it?
            
            // ISSUE: Inefficient enemy update
            foreach (var enemyObj in this.enemies)
            {
                dynamic enemy = (dynamic)enemyObj;
                enemy.Y += enemy.Speed; // ISSUE: This will cause compilation error - anonymous objects are immutable!
                
                // ISSUE: No boundary checking - enemies go off screen forever
            }
            
            // ISSUE: Bullet update also broken
            foreach (var bulletObj in this.bullets)
            {
                dynamic bullet = (dynamic)bulletObj;
                bullet.Y -= 5; // ISSUE: Same problem - can't modify anonymous object!
            }
        }
        
        // ISSUE: O(n²) collision detection - very inefficient
        private void CheckCollisions()
        {
            // ISSUE: Nested loops for collision detection - performance nightmare
            foreach (var bulletObj in this.bullets)
            {
                foreach (var enemyObj in this.enemies)
                {
                    // ISSUE: Dynamic casting in performance-critical code
                    dynamic bullet = (dynamic)bulletObj;
                    dynamic enemy = (dynamic)enemyObj;
                    
                    // ISSUE: Primitive collision detection - not accurate
                    if (bullet.X < enemy.X + enemy.Width &&
                        bullet.X + 5 > enemy.X &&
                        bullet.Y < enemy.Y + enemy.Height &&
                        bullet.Y + 10 > enemy.Y)
                    {
                        // ISSUE: Direct removal during iteration - will cause exception!
                        this.bullets.Remove(bulletObj);
                        this.enemies.Remove(enemyObj);
                        this.score += 10;
                    }
                }
            }
        }
        
        // ISSUE: This method doesn't actually remove dead objects properly
        private void RemoveDeadObjects()
        {
            // ISSUE: Logic missing - dead objects never removed
            // ISSUE: Memory leak - objects accumulate forever
        }
        
        // ISSUE: Spawn logic is completely broken
        private void SpawnEnemies()
        {
            // ISSUE: No spawn timing control
            // ISSUE: Enemies spawn constantly = performance death
            if (this.enemies.Count < 10)
            {
                var newEnemy = new { 
                    X = new Random().Next(0, 750), // ISSUE: Creating new Random each time
                    Y = 0, 
                    Width = 40, 
                    Height = 30, 
                    Health = 50,
                    Speed = 2
                };
                this.enemies.Add(newEnemy);
            }
        }
        
        // ISSUE: Paint method is inefficient and error-prone
        private void GameEngine_Paint(object sender, PaintEventArgs e)
        {
            // ISSUE: No double buffering setup
            // ISSUE: No error handling for drawing operations
            
            // Clear background
            this.g.Clear(Color.Black);
            
            // ISSUE: Drawing without checking if objects exist
            dynamic playerObj = (dynamic)this.player;
            this.g.FillRectangle(Brushes.Blue, playerObj.X, playerObj.Y, playerObj.Width, playerObj.Height);
            
            // ISSUE: Inefficient drawing loops
            foreach (var enemyObj in this.enemies)
            {
                dynamic enemy = (dynamic)enemyObj;
                this.g.FillRectangle(Brushes.Red, enemy.X, enemy.Y, enemy.Width, enemy.Height);
            }
            
            foreach (var bulletObj in this.bullets)
            {
                dynamic bullet = (dynamic)bulletObj;
                this.g.FillRectangle(Brushes.Yellow, bullet.X, bullet.Y, 5, 10);
            }
            
            // ISSUE: Text drawing without proper font disposal
            Font scoreFont = new Font("Arial", 16); // Memory leak - font never disposed
            this.g.DrawString($"Score: {this.score}", scoreFont, Brushes.White, 10, 10);
            
            // Copy buffer to screen
            e.Graphics.DrawImage(this.backBuffer, 0, 0);
        }
        
        // ISSUE: Input handling is primitive and doesn't work properly
        private void GameEngine_KeyDown(object sender, KeyEventArgs e)
        {
            // ISSUE: No input validation or error handling
            dynamic playerObj = (dynamic)this.player;
            
            switch (e.KeyCode)
            {
                case Keys.Left:
                    // ISSUE: Can't modify anonymous object - this will fail!
                    playerObj.X -= 10;
                    break;
                case Keys.Right:
                    playerObj.X += 10; // ISSUE: Same problem
                    break;
                case Keys.Space:
                    // ISSUE: Bullet creation is broken
                    this.FireBullet();
                    break;
            }
        }
        
        private void GameEngine_KeyUp(object sender, KeyEventArgs e)
        {
            // ISSUE: No key up handling - continuous movement not supported
        }
        
        // ISSUE: Firing mechanism is completely broken
        private void FireBullet()
        {
            dynamic playerObj = (dynamic)this.player;
            
            // ISSUE: Bullet positioning is wrong
            var bullet = new {
                X = playerObj.X, // Should be centered
                Y = playerObj.Y, // Should be at top of player
                Speed = 10
            };
            
            this.bullets.Add(bullet);
        }
        
        // ISSUE: No cleanup when game closes - memory leaks
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // ISSUE: Resources not disposed
            // Timer, Graphics, Bitmap all leak memory
            base.OnFormClosed(e);
        }
    }
}
