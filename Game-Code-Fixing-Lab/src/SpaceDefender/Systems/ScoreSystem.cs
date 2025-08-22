using System;
using System.Collections.Generic;
using System.IO;

namespace SpaceDefender.Systems
{
    // ISSUE: Score system that doesn't work properly
    public class ScoreSystem
    {
        // ISSUE: Public fields again
        public int CurrentScore;
        public int HighScore;
        public List<int> ScoreHistory;
        
        // ISSUE: Hardcoded file path - will break on different systems
        private string scoreFilePath = "C:\\temp\\scores.txt";
        
        // ISSUE: Constructor with potential file I/O exceptions
        public ScoreSystem()
        {
            this.CurrentScore = 0;
            this.ScoreHistory = new List<int>();
            
            // ISSUE: No error handling for file operations
            this.LoadHighScore();
        }
        
        // ISSUE: AddScore method with no validation
        public void AddScore(int points)
        {
            // ISSUE: No validation - points can be negative
            this.CurrentScore += points;
            
            // ISSUE: High score check only happens when adding score
            if (this.CurrentScore > this.HighScore)
            {
                this.HighScore = this.CurrentScore;
                // ISSUE: Save after every score update - performance killer
                this.SaveHighScore();
            }
        }
        
        // ISSUE: Reset method that doesn't reset everything
        public void ResetScore()
        {
            this.ScoreHistory.Add(this.CurrentScore);
            this.CurrentScore = 0;
            // ISSUE: High score not properly managed
        }
        
        // ISSUE: File I/O with no error handling
        private void LoadHighScore()
        {
            try
            {
                // ISSUE: File path might not exist
                if (File.Exists(this.scoreFilePath))
                {
                    string scoreText = File.ReadAllText(this.scoreFilePath);
                    // ISSUE: No validation of file content
                    this.HighScore = int.Parse(scoreText);
                }
                else
                {
                    this.HighScore = 0;
                }
            }
            catch (Exception ex)
            {
                // ISSUE: Exception swallowed - no logging
                this.HighScore = 0;
            }
        }
        
        // ISSUE: Save method with terrible error handling
        private void SaveHighScore()
        {
            try
            {
                // ISSUE: No directory check - will fail if directory doesn't exist
                File.WriteAllText(this.scoreFilePath, this.HighScore.ToString());
            }
            catch (Exception ex)
            {
                // ISSUE: Silent failure - user never knows saving failed
            }
        }
        
        // ISSUE: Method that returns internal collection - breaks encapsulation
        public List<int> GetScoreHistory()
        {
            return this.ScoreHistory; // ISSUE: Returns direct reference
        }
        
        // ISSUE: Method with hardcoded formatting
        public string GetScoreDisplay()
        {
            return $"Score: {this.CurrentScore} | High: {this.HighScore}";
        }
        
        // ISSUE: Calculation method that's inefficient
        public int CalculateAverageScore()
        {
            if (this.ScoreHistory.Count == 0) return 0;
            
            // ISSUE: Recalculates every time instead of caching
            int total = 0;
            foreach (int score in this.ScoreHistory)
            {
                total += score;
            }
            return total / this.ScoreHistory.Count;
        }
        
        // ISSUE: Method that modifies state unexpectedly
        public void ProcessEndGame()
        {
            this.ScoreHistory.Add(this.CurrentScore);
            
            // ISSUE: Automatic save without user consent
            this.SaveHighScore();
            
            // ISSUE: Score reset happens here - unexpected side effect
            this.CurrentScore = 0;
        }
        
        // ISSUE: Cleanup method that doesn't clean up properly
        public void Cleanup()
        {
            // ISSUE: Should dispose resources but doesn't
            this.ScoreHistory.Clear();
            // ISSUE: Should save current game but doesn't
        }
    }
}
