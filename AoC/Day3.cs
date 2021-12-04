using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace AoC
{
    
    public class Day3
    {
        List<string> Data { get; set; }
        public Day3()
        {
            Data = File.ReadAllLines("input_d3.txt").ToList();
        }

        private int CountZeros(int column, List<string> data)
        {
            int count = 0;
            foreach(var d in data)
            {
                if (d[column] == '0')
                    count++;
            }

            return count;
        }

        public void Part1()
        {
            string gamma = "";
            string epsilon = "";
            for (int i = 0; i < Data[0].Length; i++)
            {
                var num = CountZeros(i, Data);
                if(num <= Data.Count / 2)
                {
                    gamma += '1';
                    epsilon += '0';
                }
                else
                {
                    gamma += '0';
                    epsilon += '1';
                }
            }

            int gam32 = Convert.ToInt32(gamma, 2);
            int eps32 = Convert.ToInt32(epsilon, 2);

            Console.WriteLine($"D3.1 Sum: {gam32 * eps32}");
            
        }

        private string Scrubbing(List<string> data, bool oxy)
        {
            int columns = data[0].Length - 1;
            char toKeep;
            for(int i = 0; i < columns; i++)
            {
                
                var num = CountZeros(i, data);
                if (num <= data.Count / 2)
                {
                    if (oxy)
                        toKeep = '1';
                    else
                        toKeep = '0';
                }
                else
                {
                    if (oxy)
                        toKeep = '0';
                    else
                        toKeep = '1';
                }

                for (int j = data.Count - 1; j >= 0; j--)
                {
                    if (data[j][i] != toKeep)
                        data.RemoveAt(j);
                }

                if (data.Count == 1)
                    break;
            }

            return data.First();
        }

        public void Part2()
        {
            var oxyScrub = new List<string>(Data);
            var co2Scrub = new List<string>(Data);

            var oxy = Scrubbing(oxyScrub, true);
            var co2 = Scrubbing(co2Scrub, false);

            var oxy32 = Convert.ToInt32(oxy, 2);
            var co232 = Convert.ToInt32(co2, 2);

            Console.WriteLine($"D3.2 Sum: {oxy32 * co232}");
        }
    }
}
