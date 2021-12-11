using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace AoC
{
    public class Day8
    {
        public List<string[]> Data;
        public Day8()
        {
            Data = File.ReadAllLines("input_d8.txt").Select(x => x.Split("|")).ToList();
        }

        public void Part1()
        {
            var sum = 0;
            foreach (var input in Data)
            {
                var values = input[1].Split(" ").Where(y => y != string.Empty).ToArray();
                
                foreach(var code in values)
                {
                    switch (code.Length)
                    {
                        case 2:
                            if(values.Contains(code))
                                sum++;
                            break;
                        case 4:
                            if (values.Contains(code))
                                sum++;
                            break;
                        case 3:
                            if (values.Contains(code))
                                sum++;
                            break;
                        case 7:
                            if (values.Contains(code))
                                sum++;
                            break;
                        default:
                            break;
                    }
                }

               
            }
            Console.WriteLine($"D8.P1 Total: {sum}");
        }
    }
}
