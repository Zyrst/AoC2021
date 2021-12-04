using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace AoC
{
    public class Day4
    {
        class BingoItem
        {
            public int Value { get; set; }
            public (int, int) Pos { get; set; }
            public bool Used { get; set; }

            public BingoItem(int val, int x, int y)
            {
                Value = val;
                Pos = (x, y);
                Used = false;
            }

        }

        class BingoBoard
        {
            public List<BingoItem> BingoRows { get; set; }
            public int WinningSum { get; set; }

            public bool CheckForBingo(int lastCalledNumber)
            {
                bool bingoBongo = false;
                for (int i = 0; i < 5; i++)
                {
                    var row = BingoRows.Where(x => x.Pos.Item1 == i).Where(y => y.Used).Count() == 5;
                    var column = BingoRows.Where(x => x.Pos.Item2 == i).Where(y => y.Used).Count() == 5;
                    bingoBongo = row || column;

                    if (bingoBongo)
                    {
                        var unmarked = BingoRows.Where(x => !x.Used).Select(x => x.Value).Sum();
                        WinningSum = unmarked * lastCalledNumber;
                        break;
                    }
                }



                return bingoBongo;
            }

            public BingoBoard()
            {
                BingoRows = new List<BingoItem>();
            }

        }

        List<BingoBoard> BingoBoards { get; set; }

        int[] DrawnNumbers { get; set; }

        public Day4()
        {
            var f = File.ReadAllLines("input_d4.txt");

            var drawnNumbers = f[0];
            DrawnNumbers = drawnNumbers.Split(",").Where(x => x != string.Empty).Select(int.Parse).ToArray();

            var currentBoard = new BingoBoard();
            BingoBoards = new List<BingoBoard>();
            BingoBoards.Add(currentBoard);
            int currentRow = 0;

            for (int i = 2; i < f.Length; i++)
            {
                if (f[i] == "")
                {
                    currentBoard = new BingoBoard();
                    BingoBoards.Add(currentBoard);
                    currentRow = 0;
                }
                else
                {
                    int xPos = 0;
                    var row = f[i].Split(" ").Where(x => x != string.Empty).Select(int.Parse).Select(x => new BingoItem(x, xPos++, currentRow)).ToList();
                    currentBoard.BingoRows.AddRange(row);

                    currentRow++;
                }
            }
        }

        public void Part1()
        {
            foreach (var num in DrawnNumbers)
            {
                foreach (var board in BingoBoards)
                {
                    var def = board.BingoRows.Where(x => x.Value == num).FirstOrDefault();
                    if (def != null)
                    {
                        def.Used = true;

                        if (board.CheckForBingo(num))
                        {
                            Console.WriteLine($"D4.P1: Winning sum {board.WinningSum}");
                            return;
                        }
                    }
                }
            }
        }

        public void Part2()
        {
            foreach (var num in DrawnNumbers)
            {
                for (int i = BingoBoards.Count - 1; i > 0; i--)
                {
                    var def = BingoBoards[i].BingoRows.Where(x => x.Value == num).FirstOrDefault();
                    if (def != null)
                    {
                        def.Used = true;

                        if (BingoBoards[i].CheckForBingo(num))
                        {
                            Console.WriteLine($"D4.P2: Winning sum {BingoBoards[i].WinningSum}");
                            BingoBoards.RemoveAt(i);
                        }
                    }
                }
            }
        }
    }
}
