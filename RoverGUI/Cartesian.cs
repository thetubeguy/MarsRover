using System;

namespace RoverGUI
{
    public struct Limit
    {
        public int XLimit;
        public int YLimit;
    }
    public class Cartesian : ICoordinateSystem
    {
        public int XPosition { get; private set; }
        public int YPosition { get; private set; }

 

        public Limit _limit;

        private enum Direction { N, E, S, W }

        private Direction Facing = Direction.N;

        public RoverInstruction roverInstruction = new();

        public Cartesian()
        {
            this._limit = new Limit();
            _limit.XLimit = 24;
            _limit.YLimit = 24;

  
        }






        public string SetStartPosition(string startposition)
        {
            string[] _startpositionArray = startposition.Split(' ');
            XPosition = int.Parse(_startpositionArray[0]);
            YPosition = int.Parse(_startpositionArray[1]);
            switch (_startpositionArray[2])
            {
                case "N":
                    Facing = Direction.N;
                    break;
                case "E":
                    Facing = Direction.E;
                    break;
                case "S":
                    Facing = Direction.S;
                    break;
                case "W":
                    Facing = Direction.W;
                    break;
            };


            return startposition;
        }

        public bool ChangePosition(string instruction)
        {

            foreach (char _thisInstruction in instruction)
            {


                switch (_thisInstruction)
                {
                    case 'L':
                        Facing = (Facing == Direction.N) ? Direction.W : Facing - 1;
                        break;
                    case 'R':
                        Facing = (Facing == Direction.W) ? Direction.N : Facing + 1;
                        break;
                    case 'M':
                        switch (Facing)
                        {
                            case Direction.N:
                                if (YPosition > 0)
                                {
                                    YPosition -= 1;
                                }
                                else
                                {
                                    return false;
                                }

                                break;
                            case Direction.E:
                                if (XPosition < _limit.XLimit)
                                {
                                    XPosition += 1;
                                }
                                else
                                {
                                    return false;
                                }

                                break;
                            case Direction.S:
                                if (YPosition < _limit.YLimit)
                                {
                                    YPosition += 1;
                                }
                                else
                                {
                                    return false;
                                }

                                break;
                            case Direction.W:
                                if (XPosition > 0)
                                {
                                    XPosition -= 1;
                                }
                                else
                                {
                                    return false;
                                }

                                break;

                        }
                        break;

                }

               
            }



            return true;
        }

        public void SetLimits(string limitstring)
        {
            string[] _limitArray = limitstring.Split(' ');
            _limit.XLimit = int.Parse(_limitArray[0]);
            _limit.YLimit = int.Parse(_limitArray[1]);

        }

        public Limit GetLimits()
        {
            return _limit;
        }

        public RoverInstruction CreateRoverCommand(string thisinstruction)
        {

            RoverInstruction roverInstruction = new();

            switch (thisinstruction)
            {
                case "L":
                    roverInstruction.SetRoverInstruction(Rotation.Left, Movement.None, 90, 0);
                    break;

                case "R":
                    roverInstruction.SetRoverInstruction(Rotation.Right, Movement.None, 90, 0);
                    break;

                case "M":
                    roverInstruction.SetRoverInstruction(Rotation.None, Movement.Forwards, 0, 1);
                    break;
            }

            return roverInstruction;

        }


    }
}
