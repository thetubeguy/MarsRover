namespace RoverGUI
{
    public interface ICoordinateSystem
    {
        string SetStartPosition(string startposition);
        bool ChangePosition(string instruction);
        void SetLimits(string limitstring);

        Limit GetLimits();

        RoverInstruction CreateRoverCommand(string instruction);
    }
}
