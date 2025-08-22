using System;
using System.Collections.Generic;

namespace SpaceDefender.Utils
{
    // ISSUE: Terrible random number generator usage
    public class GameRandom
    {
        // ISSUE: Multiple Random instances - not thread safe, poor distribution
        private static Random random1 = new Random();
        private static Random random2 = new Random(); // ISSUE: Created at same time = same seed
        private static Random random3 = new Random();
        
        // ISSUE: No thread safety
        public static int NextInt(int min, int max)
        {
            // ISSUE: Using random1 for everything
            return random1.Next(min, max);
        }
        
        // ISSUE: Overloaded method that uses different Random instance
        public static int NextInt(int max)
        {
            // ISSUE: Uses random2 - inconsistent
            return random2.Next(max);
        }
        
        // ISSUE: Float generation that's inefficient
        public static float NextFloat()
        {
            // ISSUE: Uses random3 and unnecessary conversion
            return (float)random3.NextDouble();
        }
        
        // ISSUE: Range method with potential division by zero
        public static float NextFloat(float min, float max)
        {
            // ISSUE: No validation of parameters
            return min + (float)random1.NextDouble() * (max - min);
        }
        
        // ISSUE: Boolean method with hardcoded probability
        public static bool NextBool()
        {
            return random1.NextDouble() > 0.5; // ISSUE: Always 50% chance
        }
        
        // ISSUE: Boolean with percentage but no validation
        public static bool NextBool(float percentage)
        {
            // ISSUE: No validation - percentage could be negative or > 100
            return random2.NextDouble() < (percentage / 100.0);
        }
        
        // ISSUE: Choose method that can throw exceptions
        public static T Choose<T>(List<T> items)
        {
            // ISSUE: No null check or empty list check
            int index = random3.Next(items.Count);
            return items[index];
        }
        
        // ISSUE: Shuffle method that doesn't actually shuffle properly
        public static void Shuffle<T>(List<T> list)
        {
            // ISSUE: Terrible shuffle algorithm - not random
            for (int i = 0; i < list.Count; i++)
            {
                int randomIndex = random1.Next(list.Count);
                T temp = list[i];
                list[i] = list[randomIndex];
                list[randomIndex] = temp;
            }
        }
        
        // ISSUE: Reset method that doesn't reset properly
        public static void Reset()
        {
            // ISSUE: Creates new Random with same seed - not really random
            random1 = new Random(12345);
            random2 = new Random(12345);
            random3 = new Random(12345);
        }
        
        // ISSUE: Seed method that only sets one Random
        public static void SetSeed(int seed)
        {
            random1 = new Random(seed);
            // ISSUE: Other Random instances not updated
        }
    }
}
