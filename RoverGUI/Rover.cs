
using System;
using System.Threading;

namespace RoverGUI
{
    public class Rover : IRoverControl
    {
        public LunarSurface? OnSurface { get; private set; }

        public Rover(LunarSurface onsurface)
        {
            OnSurface = onsurface;

        }

        public bool MoveRover(RoverInstruction oneRoverInstruction)
        {
            return true;
        }

    }
}
