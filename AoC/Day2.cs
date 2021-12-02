using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace AoC
{
    public class Day2
    {
        struct Command
        {
            public string Dir { get; set; }
            public int Value { get; set; }

            public Command(string dir, int value)
            {
                Dir = dir;
                Value = value;
            }
        }

        Command[] Data;
        public Day2()
        {
            Data = File.ReadAllLines("input_d2.txt").Select(x => 
            { 
                var val = x.Split(" ");
                return new Command(val[0].ToLower(), int.Parse(val[1]));
            }).ToArray();
        }

        public void Part1()
        {
            int depth = 0;
            int fwd = 0;
            foreach(var cmd in Data)
            {
                switch(cmd.Dir)
                {
                    case "forward":
                        fwd += cmd.Value;
                        break;
                    case "up":
                        depth -= cmd.Value;
                        break;
                    case "down":
                        depth += cmd.Value;
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine($"Total: {fwd * depth}");
        }

        public void Part2()
        {
            int aim = 0;
            int fwd = 0;
            int depth = 0;
            foreach (var cmd in Data)
            {
                switch (cmd.Dir)
                {
                    case "forward":
                        depth += cmd.Value * aim;
                        fwd += cmd.Value;
                        break;
                    case "up":
                        aim -= cmd.Value;
                        break;
                    case "down":
                        aim += cmd.Value;
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine($"Total: {fwd * depth}");
        }
    }
}
