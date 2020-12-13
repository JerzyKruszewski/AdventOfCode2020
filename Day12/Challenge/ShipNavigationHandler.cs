using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Day12.Challenge
{
    public class ShipNavigationHandler
    {
        private static readonly Ship _ship;
        private static readonly Waypoint _waypoint;
        private static readonly IList<ShipMove> _shipMoves;

        static ShipNavigationHandler()
        {
            _ship = new Ship()
            {
                FacingDirection = 'E',
                XCord = 0,
                YCord = 0
            };

            _waypoint = new Waypoint()
            {
                XCord = 10,
                YCord = 1
            };

            _shipMoves = new List<ShipMove>();

            PopulateShipMoves();
        }

        private static void PopulateShipMoves()
        {
            using (StreamReader reader = new StreamReader("./Challenge/input.txt", Encoding.UTF8))
            {
                while (reader.Peek() >= 0)
                {
                    _shipMoves.Add(ParseShipMove(reader.ReadLine()));
                }
            }
        }

        public static ShipMove ParseShipMove(string text)
        {
            return new ShipMove()
            {
                Code = text[0],
                Value = int.Parse(text.Remove(0, 1))
            };
        }

        public static int GetDistance(int noOfChallenge, IList<ShipMove> moves = null)
        {
            if (moves == null)
            {
                moves = _shipMoves;
            }

            Reset();

            if (noOfChallenge == 1)
            {
                PerformMoveSequence(moves);
            }
            else if (noOfChallenge == 2)
            {
                PerformMoveSequenceWithWaypoint(moves);
            }

            return Math.Abs(_ship.XCord) + Math.Abs(_ship.YCord);
        }

        private static void Reset()
        {
            _ship.FacingDirection = 'E';
            _ship.XCord = 0;
            _ship.YCord = 0;

            _waypoint.XCord = 10;
            _waypoint.YCord = 1;
        }

        #region Part2
        private static void PerformMoveSequenceWithWaypoint(IList<ShipMove> moves)
        {
            foreach (ShipMove move in moves)
            {
                PerformMoveWithWaypoint(move);
            }
        }

        private static void PerformMoveWithWaypoint(ShipMove move)
        {
            switch (move.Code)
            {
                case 'F':
                    MoveShip(move.Value);
                    break;
                case 'N':
                case 'S':
                case 'E':
                case 'W':
                    MoveWaypoint(move.Code, move.Value);
                    break;
                case 'L':
                case 'R':
                    RotateWaypoint(move.Code, move.Value);
                    break;
                default:
                    break;
            }
        }

        private static void MoveShip(int value)
        {
            _ship.XCord += _waypoint.XCord * value;
            _ship.YCord += _waypoint.YCord * value;
        }

        private static void MoveWaypoint(char direction, int value)
        {
            switch (direction)
            {
                case 'N':
                    _waypoint.YCord += value;
                    break;
                case 'S':
                    _waypoint.YCord -= value;
                    break;
                case 'E':
                    _waypoint.XCord += value;
                    break;
                case 'W':
                    _waypoint.XCord -= value;
                    break;
                default:
                    break;
            }
        }

        private static void RotateWaypoint(char direction, int value)
        {
            switch (direction)
            {
                case 'L':
                    switch (value)
                    {
                        case 90:
                            //X = -Y
                            //Y = X
                            SwapWayPointCords(-_waypoint.YCord, _waypoint.XCord);
                            break;
                        case 180:
                            //X = -X
                            //Y = -Y
                            SwapWayPointCords(-_waypoint.XCord, -_waypoint.YCord);
                            break;
                        case 270:
                            //X = Y
                            //Y = -X
                            SwapWayPointCords(_waypoint.YCord, -_waypoint.XCord);
                            break;
                        default:
                            break;
                    }
                    break;
                case 'R':
                    switch (value)
                    {
                        case 90:
                            //X = Y
                            //Y = -X
                            SwapWayPointCords(_waypoint.YCord, -_waypoint.XCord);
                            break;
                        case 180:
                            //X = -X
                            //Y = -Y
                            SwapWayPointCords(-_waypoint.XCord, -_waypoint.YCord);
                            break;
                        case 270:
                            //X = -Y
                            //Y = X
                            SwapWayPointCords(-_waypoint.YCord, _waypoint.XCord);
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

        private static void SwapWayPointCords(int newXCord, int newYCord)
        {
            _waypoint.XCord = newXCord;
            _waypoint.YCord = newYCord;
        }
        #endregion

        #region Part1
        private static void PerformMoveSequence(IList<ShipMove> moves)
        {
            foreach (ShipMove move in moves)
            {
                PerformMove(move);
            }
        }

        private static void PerformMove(ShipMove move)
        {
            switch (move.Code)
            {
                case 'F':
                    Move(_ship.FacingDirection, move.Value);
                    break;
                case 'N':
                case 'S':
                case 'E':
                case 'W':
                    Move(move.Code, move.Value);
                    break;
                case 'L':
                case 'R':
                    Rotate(move.Code, move.Value);
                    break;
                default:
                    break;
            }
        }

        private static void Move(char direction, int value)
        {
            switch (direction)
            {
                case 'N':
                    _ship.YCord += value;
                    break;
                case 'S':
                    _ship.YCord -= value;
                    break;
                case 'E':
                    _ship.XCord += value;
                    break;
                case 'W':
                    _ship.XCord -= value;
                    break;
                default:
                    break;
            }
        }

        private static void Rotate(char direction, int value)
        {
            string directions = "NESW";
            string reversed = "WSEN";
            int index;


            switch (direction)
            {
                case 'L':
                    //-
                    index = reversed.IndexOf(_ship.FacingDirection);
                    _ship.FacingDirection = reversed[(index + value / 90) % reversed.Length];
                    break;
                case 'R':
                    //+
                    index = directions.IndexOf(_ship.FacingDirection);
                    _ship.FacingDirection = directions[(index + value / 90) % directions.Length];
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}
