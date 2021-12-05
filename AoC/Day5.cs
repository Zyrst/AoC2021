using System.IO;
using System.Linq;
using System;

namespace AoC
{
    public class Day5
    {
        public class Point
        {
            public int X { get; set; }
            public int Y { get; set; }

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        public class LineSegment
        {
            public Point Start { get; set; }
            public Point End { get; set; }

            public LineSegment(string input)
            {
                var seperatedPoints = input.Split("->");
                var p = seperatedPoints[0].Split(",").Select(int.Parse).ToArray();
                Start = new Point(p[0], p[1]);
                p = seperatedPoints[1].Split(",").Select(int.Parse).ToArray();
                End = new Point(p[0], p[1]);
            }

        }

        public LineSegment[] LineSegments { get; set; }

        public Day5()
        {
            var lines = File.ReadAllLines("input_d5.txt");
            LineSegments = lines.Select(x => new LineSegment(x)).ToArray();

        }

        public int Solve(bool useDiagonal)
        {
            var grid = new int[1000, 1000];

            foreach (var line in LineSegments)
            {
                if (line.Start.X == line.End.X || line.Start.Y == line.End.Y)
                {
                    var xDiff = line.Start.X - line.End.X;
                    var yDiff = line.Start.Y - line.End.Y;

                    for (int i = 0; i < Math.Abs(xDiff) + 1; i++)
                        for (int j = 0; j < Math.Abs(yDiff) + 1; j++)
                        {
                            var x = line.Start.X + (xDiff < 0 ? i : i * -1);
                            var y = line.Start.Y + (yDiff < 0 ? j : j * -1);

                            grid[x, y]++;
                        }
                }
                else if(useDiagonal)
                {
                    var xDiff = line.Start.X - line.End.X;
                    var yDiff = line.Start.Y - line.End.Y;

                    for (int i = 0; i < Math.Abs(xDiff) + 1; i++)
                    {
                        var xCoord = line.Start.X + ((xDiff < 0) ? i : i * -1);
                        var yCoord = line.Start.Y + ((yDiff < 0) ? i : i * -1);
                        grid[xCoord, yCoord]++;
                    }
                }
            }

            var tot = grid.Cast<int>().Where(x => x > 1).Count();

            return tot;
        }

        public void Part1()
        {
            var tot = Solve(false);
            Console.WriteLine($"D5.P1 Total: {tot}");
        }

        public void Part2()
        {
            var tot = Solve(true);
            Console.WriteLine($"D5.P2 Total: {tot}");
        }
    }
}
