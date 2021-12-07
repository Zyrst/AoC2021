using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace AoC
{
    public class Day7
    {
        public int[] CrabPos { get; set; }

        public Day7()
        {
            CrabPos = File.ReadAllLines("input_d7.txt")[0].Split(",").Select(int.Parse).ToArray();
        }

        public void Part1()
        {
            // Try finding the average and work around there
            int avg = CrabPos.Sum() / CrabPos.Length;
            int lowest = CrabPos.Select(x => Math.Abs(avg - 50)).Sum();
            var lowestPos = avg - 50;
            for (int i = avg - 200; i < avg + 200; i++)
            {
                var t = CrabPos.Select(x => Math.Abs(i - x)).Sum();
                if (t < lowest)
                {
                    lowest = t; 
                    lowestPos = i;
                }
            }

            Console.WriteLine($"Test with average calc : {lowest}  {lowestPos}");

        }

        public void Part2()
        {
            int avg = CrabPos.Sum() / CrabPos.Length;
            int lowest = 0;
            var lowestPos = 0;
            for (int i = avg - 200; i < avg + 200; i++)
            {
                var t = CrabPos.Select(x => Math.Abs(i - x)).Select(y => ((y*y) + y) / 2).Sum();
                if (t < lowest || lowest == 0)
                {
                    lowest = t;
                    lowestPos = i;
                }
            }

            Console.WriteLine($"Test with average calc : {lowest}  {lowestPos}");

        }
    }
}
