using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace AoC
{
    public class Day6
    {
        public class Fish
        {
            public int Days { get; set; }
            public ulong Count { get; set; }

        }
        public List<Fish> Fishes { get; set; }


        public ulong FishProduction(int days)
        {
            for (int i = 0; i < days; i++)
            {
                UInt64 fishesToAdd = 0;
                for (int j = Fishes.Count -1; j >= 0; j--)
                {
                    Fishes[j].Days--;
                    if (Fishes[j].Days < 0)
                    {
                        fishesToAdd += Fishes[j].Count;
                        Fishes[j].Days = 6;
                    }
                }

                if (fishesToAdd > 0)
                    Fishes.Add(new Fish { Count = fishesToAdd, Days = 8 });
            }

            var counts = Fishes.Select(x => x.Count);
            ulong finalFishes = 0;
            foreach (var cnt in counts)
                finalFishes += cnt;

            return finalFishes;
        }

        public void Part1()
        {
            var t = File.ReadAllLines("input_d6.txt")[0].Split(",").Select(int.Parse).GroupBy(y => y).ToArray();
            Fishes = t.Select(x => new Fish { Count = (ulong)x.Count(), Days = x.Key }).ToList();
            var fishes = FishProduction(80);
            Fishes.Clear();
            Console.WriteLine($"D5.P1 Fishes {fishes}");
        }

        public void Part2()
        {
            var t = File.ReadAllLines("input_d6.txt")[0].Split(",").Select(int.Parse).GroupBy(y => y).ToArray();
            Fishes = t.Select(x => new Fish { Count = (ulong)x.Count(), Days = x.Key }).ToList();
            var fishes = FishProduction(256);
            Fishes.Clear();
            Console.WriteLine($"D5.P2 Fishes {fishes}");
        }
    }
}
