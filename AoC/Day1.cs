using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AoC
{
    public class Day1
    {
        public int[] Data;

        public Day1()
        {
            Data = File.ReadAllLines("input_d1.txt").Select(x => int.Parse(x)).ToArray();
        }

        public void Part1()
        {
            var dt = Data.Zip(Data.Skip(1), (x, y) => y > x).Where(x => x).ToArray();

            Console.WriteLine($"Increases: {dt.Length}");
        }

        public void Part2()
        {
            // Sliding window of 3 

            int a, b, c, tot, inc;
            a = Data[0];
            b = Data[1];
            c = Data[2];
            tot = a + b + c;
            inc = 0;

            for(int i = 3; i < Data.Length; i++)
            {
                switch(i % 3)
                {
                    case 0:
                        a = Data[i];
                        break;
                    case 1:
                        b = Data[i];
                        break;
                    case 2:
                        c = Data[i];
                        break;
                }
                if ((a + b + c) > tot)
                    inc++;
                tot = a + b + c;
            }

            Console.WriteLine($"Increases: {inc}");

        }
    }
}
