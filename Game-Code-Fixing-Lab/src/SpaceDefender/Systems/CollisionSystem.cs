using System;
using System.Collections.Generic;
using SpaceDefender.Entities;

namespace SpaceDefender.Systems
{
    // ISSUE: Collision system with O(n²) complexity
    public class CollisionSystem
    {
        // ISSUE: Public lists that can be modified externally
        public List<Player> Players;
        public List<Enemy> Enemies;
        public List<Bullet> Bullets;
        
        // ISSUE: Constructor that does too much
        public CollisionSystem()
        {
            this.Players = new List<Player>();
            this.Enemies = new List<Enemy>();
            this.Bullets = new List<Bullet>();
        }
        
        // ISSUE: Update method with nested loops - performance nightmare
        public void UpdateCollisions()
        {
            // ISSUE: No null checks anywhere
            this.CheckBulletEnemyCollisions();
            this.CheckBulletPlayerCollisions();
            this.CheckPlayerEnemyCollisions();
            
            // ISSUE: Cleanup is separate and inefficient
            this.RemoveDestroyedObjects();
        }
        
        // ISSUE: O(n*m) collision detection
        private void CheckBulletEnemyCollisions()
        {
            // ISSUE: Nested loops with no spatial optimization
            foreach (var bullet in this.Bullets)
            {
                foreach (var enemy in this.Enemies)
                {
                    // ISSUE: Collision check repeated for same objects
                    if (bullet.CollidesWith(enemy))
                    {
                        // ISSUE: Hardcoded damage values
                        enemy.TakeDamage(25);
                        
                        // ISSUE: Mark for removal in inefficient way
                        bullet.Speed = -999; // ISSUE: Hack to mark for removal
                        
                        // ISSUE: No collision effects or feedback
                        
                        // ISSUE: Break after first collision - bullets can't hit multiple enemies
                        break;
                    }
                }
            }
        }
        
        // ISSUE: Duplicate logic from above method
        private void CheckBulletPlayerCollisions()
        {
            foreach (var bullet in this.Bullets)
            {
                foreach (var player in this.Players)
                {
                    if (bullet.CollidesWith(player))
                    {
                        // ISSUE: Different damage value hardcoded
                        player.TakeDamage(10);
                        
                        // ISSUE: Same removal hack
                        bullet.Speed = -999;
                        
                        break;
                    }
                }
            }
        }
        
        // ISSUE: More nested loops
        private void CheckPlayerEnemyCollisions()
        {
            foreach (var player in this.Players)
            {
                foreach (var enemy in this.Enemies)
                {
                    if (player.CollidesWith(enemy))
                    {
                        // ISSUE: Massive damage for touching enemy
                        player.TakeDamage(50);
                        enemy.TakeDamage(100); // ISSUE: Enemy dies from touching player
                        
                        // ISSUE: No collision response (bouncing, etc.)
                    }
                }
            }
        }
        
        // ISSUE: Inefficient cleanup method
        private void RemoveDestroyedObjects()
        {
            // ISSUE: Remove while iterating - potential issues
            for (int i = this.Bullets.Count - 1; i >= 0; i--)
            {
                // ISSUE: Using speed hack to determine removal
                if (this.Bullets[i].Speed == -999 || this.Bullets[i].IsOffScreen())
                {
                    this.Bullets.RemoveAt(i);
                }
            }
            
            // ISSUE: Different removal logic for enemies
            for (int i = this.Enemies.Count - 1; i >= 0; i--)
            {
                if (!this.Enemies[i].IsAlive() || this.Enemies[i].IsOffScreen())
                {
                    this.Enemies.RemoveAt(i);
                }
            }
            
            // ISSUE: No removal logic for dead players
        }
        
        // ISSUE: Methods to add objects - breaks encapsulation
        public void AddPlayer(Player player)
        {
            // ISSUE: No validation
            this.Players.Add(player);
        }
        
        public void AddEnemy(Enemy enemy)
        {
            // ISSUE: No validation
            this.Enemies.Add(enemy);
        }
        
        public void AddBullet(Bullet bullet)
        {
            // ISSUE: No validation, unlimited bullets
            this.Bullets.Add(bullet);
        }
        
        // ISSUE: Clear method that doesn't properly clean up
        public void ClearAll()
        {
            this.Players.Clear();
            this.Enemies.Clear();
            this.Bullets.Clear();
            // ISSUE: No disposal of resources
        }
        
        // ISSUE: Debug method that returns internal state
        public int GetCollisionCount()
        {
            // ISSUE: Returns total objects, not actual collisions
            return this.Players.Count + this.Enemies.Count + this.Bullets.Count;
        }
        
        // ISSUE: Method that checks specific collision - inefficient
        public bool IsPlayerHit(Player player)
        {
            // ISSUE: Recalculates collisions just for this check
            foreach (var enemy in this.Enemies)
            {
                if (player.CollidesWith(enemy)) return true;
            }
            
            foreach (var bullet in this.Bullets)
            {
                if (bullet.Owner == "Enemy" && bullet.CollidesWith(player)) return true;
            }
            
            return false;
        }
    }
}
