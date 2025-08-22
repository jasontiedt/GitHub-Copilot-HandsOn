using System;
using System.Windows.Forms;

namespace SpaceDefender
{
    // ISSUE: Program class has no error handling
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // ISSUE: No try-catch for initialization errors
            // ISSUE: No application configuration
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // ISSUE: No error handling - if GameEngine constructor fails, app crashes
            var game = new Game.GameEngine();
            
            // ISSUE: No graceful shutdown handling
            Application.Run(game);
        }
    }
}
