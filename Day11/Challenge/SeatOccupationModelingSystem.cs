using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Day11.Challenge
{
    public class SeatOccupationModelingSystem
    {
        private static string _seats;

        static SeatOccupationModelingSystem()
        {
            using (StreamReader reader = new StreamReader("./Challenge/input.txt", Encoding.UTF8))
            {
                _seats = reader.ReadToEnd();
            }
        }

        public static string Iterate(int maxToOccupy, int minToEmpty, int noOfChallenge, string seats = "")
        {
            if (string.IsNullOrEmpty(seats))
            {
                seats = _seats;
            }

            string[] origin = seats.Split("\r\n");
            string[] copy = seats.Split("\r\n");

            CellularAutomata(maxToOccupy, minToEmpty, noOfChallenge, origin, copy);

            origin = copy;
            seats = "";

            for (int i = 0; i < origin.Length; i++)
            {
                if (i == 0)
                {
                    seats += $"{origin[i]}";
                }
                else
                {
                    seats += $"\r\n{origin[i]}";
                }
            }

            return seats;
        }

        private static void CellularAutomata(int maxToOccupy, int minToEmpty, int noOfChallenge, string[] origin, string[] copy)
        {
            for (int i = 0; i < origin.Length; i++)
            {
                for (int j = 0; j < origin[i].Length; j++)
                {
                    if (noOfChallenge == 1)
                    {
                        if (origin[i][j] == '.')
                        {
                            copy[i] = $"{copy[i].Substring(0, j)}.{copy[i].Substring(j + 1, copy[i].Length - j - 1)}";
                        }
                        else if (CountNeighbours(origin, i, j) >= minToEmpty)
                        {
                            copy[i] = $"{copy[i].Substring(0, j)}L{copy[i].Substring(j + 1, copy[i].Length - j - 1)}";
                        }
                        else if (CountNeighbours(origin, i, j) <= maxToOccupy)
                        {
                            copy[i] = $"{copy[i].Substring(0, j)}#{copy[i].Substring(j + 1, copy[i].Length - j - 1)}";
                        }
                        else
                        {
                            copy[i] = $"{copy[i].Substring(0, j)}{origin[i][j]}{copy[i].Substring(j + 1, copy[i].Length - j - 1)}";
                        }
                    }
                    if (noOfChallenge == 2)
                    {
                        if (origin[i][j] == '.')
                        {
                            copy[i] = $"{copy[i].Substring(0, j)}.{copy[i].Substring(j + 1, copy[i].Length - j - 1)}";
                        }
                        else if (CountVisibility(origin, i, j) >= minToEmpty)
                        {
                            copy[i] = $"{copy[i].Substring(0, j)}L{copy[i].Substring(j + 1, copy[i].Length - j - 1)}";
                        }
                        else if (CountVisibility(origin, i, j) <= maxToOccupy)
                        {
                            copy[i] = $"{copy[i].Substring(0, j)}#{copy[i].Substring(j + 1, copy[i].Length - j - 1)}";
                        }
                        else
                        {
                            copy[i] = $"{copy[i].Substring(0, j)}{origin[i][j]}{copy[i].Substring(j + 1, copy[i].Length - j - 1)}";
                        }
                    }
                }
            }
        }

        private static int CountNeighbours(string[] origin, int row, int column)
        {
            int neighbours = 0;

            if (row > 0)
            {
                if (origin[row - 1][column] == '#')
                {
                    neighbours++;
                }
                if (column > 0)
                {
                    if (origin[row - 1][column - 1] == '#')
                    {
                        neighbours++;
                    }
                }
                if (column < origin[row - 1].Length - 1)
                {
                    if (origin[row - 1][column + 1] == '#')
                    {
                        neighbours++;
                    }
                }
            }

            if (column > 0)
            {
                if (origin[row][column - 1] == '#')
                {
                    neighbours++;
                }
            }
            if (column < origin[row].Length - 1)
            {
                if (origin[row][column + 1] == '#')
                {
                    neighbours++;
                }
            }

            if (row < origin.Length - 1)
            {
                if (origin[row + 1][column] == '#')
                {
                    neighbours++;
                }
                if (column > 0)
                {
                    if (origin[row + 1][column - 1] == '#')
                    {
                        neighbours++;
                    }
                }
                if (column < origin[row + 1].Length - 1)
                {
                    if (origin[row + 1][column + 1] == '#')
                    {
                        neighbours++;
                    }
                }
            }

            return neighbours;
        }

        private static int CountVisibility(string[] origin, int row, int column)
        {
            int visibility = 0;

            //UP
            for (int j = row - 1; j >= 0; j--)
            {
                if (origin[j][column] == 'L')
                {
                    break;
                }
                if (origin[j][column] == '#')
                {
                    visibility++;
                    break;
                }
            }
            //DOWN
            for (int j = row + 1; j < origin.Length; j++)
            {
                if (origin[j][column] == 'L')
                {
                    break;
                }
                if (origin[j][column] == '#')
                {
                    visibility++;
                    break;
                }
            }
            //LEFT
            for (int j = column - 1; j >= 0; j--)
            {
                if (origin[row][j] == 'L')
                {
                    break;
                }
                if (origin[row][j] == '#')
                {
                    visibility++;
                    break;
                }
            }
            //RIGHT
            for (int j = column + 1; j < origin[row].Length; j++)
            {
                if (origin[row][j] == 'L')
                {
                    break;
                }
                if (origin[row][j] == '#')
                {
                    visibility++;
                    break;
                }
            }

            //Diagnal
            int i = 1;
            while (i < origin[row].Length - column && i < origin.Length - row)
            {
                if (origin[row + i][column + i] == 'L')
                {
                    break;
                }
                if (origin[row + i][column + i] == '#')
                {
                    visibility++;
                    break;
                }

                i++;
            }

            i = 1;
            while (i <= column && i < origin.Length - row)
            {
                if (origin[row + i][column - i] == 'L')
                {
                    break;
                }
                if (origin[row + i][column - i] == '#')
                {
                    visibility++;
                    break;
                }

                i++;
            }

            i = 1;
            while (i <= row && i < origin[row].Length - column)
            {
                if (origin[row - i][column + i] == 'L')
                {
                    break;
                }
                if (origin[row - i][column + i] == '#')
                {
                    visibility++;
                    break;
                }

                i++;
            }

            i = 1;
            while (i <= column && i <= row)
            {
                if (origin[row - i][column - i] == 'L')
                {
                    break;
                }
                if (origin[row - i][column - i] == '#')
                {
                    visibility++;
                    break;
                }

                i++;
            }

            return visibility;
        }

        public static int GetOccupiedSeats(int maxToOccupy, int minToEmpty, int noOfChallenge)
        {
            string was = _seats;
            string seats = Iterate(maxToOccupy, minToEmpty, noOfChallenge);

            while (was != seats)
            {
                was = seats;
                seats = Iterate(maxToOccupy, minToEmpty, noOfChallenge, was);
            }

            return CountElements('#', seats);
        }

        private static int CountElements(char character, string sequence)
        {
            int counter = 0;

            foreach (char item in sequence)
            {
                if (item == character)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
