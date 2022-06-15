using RoverGUI;
using System;
namespace MissionControl
{
    public partial class MissionControlConsole : Form
    {
        RoverInstruction pathInstruction;
        public Rover rover;
        public MissionControlConsole()
        {
            InitializeComponent();
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            updatePath("M");
                       
        }

        private void cmdLeft_Click(object sender, EventArgs e)
        {
            updatePath("L");

        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            updatePath("R");

        }

        private void updatePath(string movement)
        {
            bool _movementOk = rover.OnSurface.CoordinateSystem.ChangePosition(movement);

            if (_movementOk)
            {
               
                txtCommandList.Text += movement;
                pathInstruction = rover.OnSurface.CoordinateSystem.CreateRoverCommand(movement);
                rover.OnSurface.UpdateMap(pathInstruction, ref rover.OnSurface.renderSurface.PathAngle, ref rover.OnSurface.renderSurface.PathPosition);
     
            }
        }

        private void cmdExecute_Click(object sender, EventArgs e)
        {
      

            Thread.Sleep(1000);

            RoverInstruction TestInstruction;


            foreach (char command in txtCommandList.Text)
            {
                TestInstruction = rover.OnSurface.CoordinateSystem.CreateRoverCommand(command.ToString());
                bool v = SendRoverCommand(TestInstruction);
                if (v)
                {
                    rover.OnSurface.UpdateMap(TestInstruction, ref rover.OnSurface.renderSurface.RoverAngle, ref rover.OnSurface.renderSurface.RoverPosition);
                }
             
            }

            txtCommandList.Clear();


        }

        public event EventHandler<RoverCommandEventArgs> RoverCommandEvent;
        public bool SendRoverCommand(RoverInstruction oneInstruction)
        {

            OnRoverCommandEvent(new RoverCommandEventArgs(oneInstruction._moveCommand));
            return true;
        }

        protected virtual void OnRoverCommandEvent(RoverCommandEventArgs args)
        {
            EventHandler<RoverCommandEventArgs>? _tempCopy = RoverCommandEvent;

            if (RoverCommandEvent != null)
            {
                RoverCommandEvent(this, args);
            }


        }

        private void MissionControlConsole_Load(object sender, EventArgs e)
        {
   

            rover = new Rover(new LunarSurface("Rectangle", new Cartesian()));
            startposX.Maximum = rover.OnSurface.CoordinateSystem.GetLimits().XLimit;
            startposY.Maximum = rover.OnSurface.CoordinateSystem.GetLimits().YLimit;

        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            int x = (int)((startposX.Value * rover.OnSurface.UnitSize) + (rover.OnSurface.UnitSize / 2));
            int y = (int)((startposY.Value * rover.OnSurface.UnitSize) + (rover.OnSurface.UnitSize / 2));

            string positionString = startposX.Value + " " + startposY.Value + " " + "N";
            string renderPositionString = x.ToString() + " " + y.ToString() + " " + "N";
            rover.OnSurface.CoordinateSystem.SetStartPosition(positionString);
            rover.OnSurface.renderSurface.RenderStartPosition(renderPositionString);
        }
    }
}