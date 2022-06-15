using System;
namespace RoverGUI
{
    public enum Rotation { Left, Right, None };
    public enum Movement { Forwards, Backwards, None };

    public struct MoveCommand
    {
        public Rotation RotateDirection;
        public Movement MovementDirection;
        public int RotateDegrees;
        public int MovementValue;
    }

    public class RoverInstruction
    {
        public int RotateDegrees;

        public MoveCommand _moveCommand = new();

        public void SetRoverInstruction(Rotation rotatedirection, Movement movementdirection, int rotatedegrees, int movementvalue)
        {

            _moveCommand.RotateDirection = rotatedirection;
            _moveCommand.MovementDirection = movementdirection;
            _moveCommand. MovementValue = movementvalue;
            _moveCommand.RotateDegrees = rotatedegrees;
        }

 
    }

    public class RoverCommandEventArgs : EventArgs
    {
        public MoveCommand ThisMoveCommand{ get; private set; }

        public RoverCommandEventArgs(MoveCommand moveCommand)
        {
            ThisMoveCommand = moveCommand;    
        }
    }

 
}
