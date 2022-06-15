using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverGUI
{
    public class MissionControl
    {
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
    }
}
