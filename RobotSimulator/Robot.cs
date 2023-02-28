using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSimulator
{
    public class Robot
    {
        private static Robot _instance;

        private int _currentX;
        private int _currentY;
        private string _currentFacing;

        private Robot(int x, int y, string facing)
        {
            _currentX = x;
            _currentY = y;
            _currentFacing = facing;
        }

        public static Robot Place(int x, int y, string facing)
        {
            if (DimensionConsts.MIN <= x && x <= DimensionConsts.MAX
                    && DimensionConsts.MIN <= y && y <= DimensionConsts.MAX)
            {
                if (_instance == null)
                {
                    _instance = new Robot(x, y, facing);
                }
                else _instance.InnerPlace(x, y, facing);
            }

            return _instance;
        }

        private void InnerPlace(int x, int y, string facing)
        {
            _currentX = x;
            _currentY = y;
            _currentFacing = facing;
        }

        public void Move()
        {
            switch (_currentFacing)
            {
                case FacingConsts.EAST:
                    TryMove(1, 0);
                    break;
                case FacingConsts.WEST:
                    TryMove(-1, 0);
                    break;
                case FacingConsts.SOUTH:
                    TryMove(0, -1);
                    break;
                case FacingConsts.NORTH:
                    TryMove(0, 1);
                    break;
            }
        }



        public void Report()
        {
            Console.WriteLine($"{_currentX},{_currentY},{_currentFacing}");
        }

        private void TryMove(int x, int y)
        {
            var newX = _currentX + x;
            var newY = _currentY + y;

            if (DimensionConsts.MIN <= newX && newX <= DimensionConsts.MAX
                    && DimensionConsts.MIN <= newY && newY <= DimensionConsts.MAX)
            {
                _currentX = newX;
                _currentY = newY;
            }
        }

        // for RIGHT turn
        public void TurnCW()
        {
            switch (_currentFacing)
            {
                case FacingConsts.EAST:
                    _currentFacing = FacingConsts.SOUTH;
                    break;
                case FacingConsts.WEST:
                    _currentFacing = FacingConsts.NORTH;
                    break;
                case FacingConsts.SOUTH:
                    _currentFacing = FacingConsts.WEST;
                    break;
                case FacingConsts.NORTH:
                    _currentFacing = FacingConsts.EAST;
                    break;
            }
        }

        public void TurnCCW()
        {
            switch (_currentFacing)
            {
                case FacingConsts.EAST:
                    _currentFacing = FacingConsts.NORTH;
                    break;
                case FacingConsts.WEST:
                    _currentFacing = FacingConsts.SOUTH;
                    break;
                case FacingConsts.SOUTH:
                    _currentFacing = FacingConsts.EAST;
                    break;
                case FacingConsts.NORTH:
                    _currentFacing = FacingConsts.WEST;
                    break;
            }
        }
    }
}
