using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSimulator
{
    public class Program
    {
        private static Robot _robot;

        static void Main(string[] args)
        {
            string[] commands = File.ReadAllLines("commands.txt");

            foreach (var command in commands)
            {
                if (!string.IsNullOrEmpty(command?.Trim()))
                {
                    var arguments = command.Trim().Split(' ');
                    ExecuteCommand(arguments);
                }
            }

            Console.ReadLine();
        }

        private static void ExecuteCommand(string[] args)
        {
            var command = args[0].ToUpper();

            switch (command)
            {
                case "PLACE":
                    if (args.Length < 2)
                    {
                        Console.WriteLine("Missing argument for PLACE command");
                        return;
                    }
                    var positionArgs = args[1].Split(',');
                    int x, y;
                    if (int.TryParse(positionArgs[0], out x) && int.TryParse(positionArgs[1], out y))
                    {
                        _robot = Robot.Place(x, y, positionArgs[2]);
                    }

                    break;
                case "MOVE":
                    _robot?.Move();
                    break;
                case "LEFT":
                    _robot?.TurnCCW();
                    break;
                case "RIGHT":
                    _robot?.TurnCW();
                    break;
                case "REPORT":
                    _robot?.Report();
                    break;
            }
        }
    }
}
