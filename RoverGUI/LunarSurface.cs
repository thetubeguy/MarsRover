
using System.Threading.Tasks;
using System;
using System.Threading;
using Microsoft.Xna.Framework;


namespace RoverGUI
{
    public class LunarSurface
    {
        public Task GUITask;

        public int UnitSize = 36;
        public string? Shape { get; set; }
        public ICoordinateSystem? CoordinateSystem { get; set; }

        public RenderSurface? renderSurface;

        public LunarSurface(string shape, ICoordinateSystem coordinateSystem)
        {
            Shape = shape;
            CoordinateSystem = coordinateSystem;

            GUITask =  Task.Factory.StartNew(() =>
            {
                renderSurface = new RenderSurface();
                renderSurface.Run();
            });
          
        }

        

        public void UpdateMap(RoverInstruction roverInstruction, ref float angle, ref Vector2 thisPosition)
        {
            switch (roverInstruction._moveCommand.RotateDirection)
            {
                case Rotation.Left:
                    rotateSmoothly(ref angle, false, roverInstruction._moveCommand.RotateDegrees);
                    break;
                case Rotation.Right:
                    rotateSmoothly(ref angle, true, roverInstruction._moveCommand.RotateDegrees);
                    break;

            }
            if (roverInstruction._moveCommand.MovementValue != 0)
            {
                switch (angle)
                {
                    case 0:
                        moveSmoothly(ref thisPosition.Y, false, UnitSize);
                        break;
                    case 90:
                        moveSmoothly(ref thisPosition.X, true, UnitSize);
                        break;
                    case 180:
                        moveSmoothly(ref thisPosition.Y, true, UnitSize);
                        break;
                    case 270:
                        moveSmoothly(ref thisPosition.X, false, UnitSize);
                        break;
                }



            }


        }

 

        void moveSmoothly(ref float axis, bool direction, int amount)
        {

            for (int i = 0; i < amount; i++)
            {
                if (direction)
                {
                    axis += 1;
                }
                else
                {
                    axis -= 1;
                }
                Thread.Sleep(10);
            }

        }

        void rotateSmoothly(ref float axis, bool direction, int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                if (direction)
                {
                    axis += 1;
                    if (axis == 360) axis = 0;
                }
                else
                {
                    axis -= 1;
                    if (axis == -1) axis = 359;
                }
                Thread.Sleep(10);
            }

        }
    }
    
}
