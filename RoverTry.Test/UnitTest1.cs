using FluentAssertions;
using NUnit.Framework;
using RoverGUI;
using System.Threading;


namespace RoverTry.Test
{
    public class Tests
    {
        public Rover? rover, rover2;

        [SetUp]
        public void Setup()
        {
            rover = new Rover(new LunarSurface("Rectangle", new Cartesian()));
            //rover2 = new Rover(new LunarSurface("Sphere", new Geographic()));

        }


        [Test]
        public void Start_Position_1_2_N_And_Instruction_LMLMLMLMM_Should_Output_1_3_N()
        {
            string actual_output = rover.OnSurface.CoordinateSystem.SetStartPosition("1 2 N");
            actual_output = rover.OnSurface.CoordinateSystem.ChangePosition("LMLMLMLMM");

            actual_output.Should().Be("1 3 N");
        }


        [Test]
        public void Start_Position_3_3_E_And_Instruction_MMRMMRMRRM_Should_Output_5_1_E()
        {
            string actual_output = rover.OnSurface.CoordinateSystem.SetStartPosition("3 3 E");
            actual_output = rover.OnSurface.CoordinateSystem.ChangePosition("MMRMMRMRM");

            //actual_output.Should().Be("5 1 E");

            rover.OnSurface.GUITask.Wait();

        }
        [Test]
        public void OneMove()
        {
            string actual_output = rover.OnSurface.CoordinateSystem.SetStartPosition("3 3 E");
            actual_output = rover.OnSurface.CoordinateSystem.ChangePosition("R");

            //actual_output.Should().Be("5 1 E");

            Thread.Sleep(1000);

            RoverInstruction TestInstruction;

            foreach (char command in "RMMMLMMMLMM")
            {
                MissionControl missionControl = new();
                TestInstruction = rover.OnSurface.CoordinateSystem.CreateRoverCommand(command.ToString());
                bool v = missionControl.SendRoverCommand(TestInstruction);
                if (v)
                {
                    rover.OnSurface.UpdateMap(TestInstruction);
                }
                //Thread.Sleep(100);
            }
            

            rover.OnSurface.GUITask.Wait();

            

        }


        [Test]
        public void Start_Position_4_5_E_And_Instruction_MMMMMMMM_Limits_10_10_Should_Output_10_5_E()
        {
            string actual_output = rover.OnSurface.CoordinateSystem.SetStartPosition("4 5 E");
            rover.OnSurface.CoordinateSystem.SetLimits("10 10");
            actual_output = rover.OnSurface.CoordinateSystem.ChangePosition("MMMMMMMM");

            actual_output.Should().Be("10 5 E");
        }

        [Test]
        public void Start_Position_15_07_S_And_Instruction_MMMMMMMMMM_Limits_20_20_Should_Output_13_0_S()
        {
            string actual_output = rover.OnSurface.CoordinateSystem.SetStartPosition("15 07 S");
            rover.OnSurface.CoordinateSystem.SetLimits("20 20");
            actual_output = rover.OnSurface.CoordinateSystem.ChangePosition("MMMMMMMMRMMLM");

            actual_output.Should().Be("13 0 S");
        }

        [Test]
        public void Start_Position_2_48_S_And_Instruction_RMMM_Limits_50_50_Should_Output_0_48_W()
        {
            string actual_output = rover.OnSurface.CoordinateSystem.SetStartPosition("2 48 S");
            rover.OnSurface.CoordinateSystem.SetLimits("50 50");
            actual_output = rover.OnSurface.CoordinateSystem.ChangePosition("RMMM");

            actual_output.Should().Be("0 48 W");
        }
        [Test]
        public void Start_Position_1000_998_S_And_Instruction_LLMMM_Limits_1000_1000_Should_Output_1000_1000_N()
        {
            string actual_output = rover.OnSurface.CoordinateSystem.SetStartPosition("1000 998 S");
            rover.OnSurface.CoordinateSystem.SetLimits("1000 1000");
            actual_output = rover.OnSurface.CoordinateSystem.ChangePosition("LLMMM");

            actual_output.Should().Be("1000 1000 N");
        }

        [Test]
        public void Start_Position_005E_030N_Facing_N_End_Position_015E_030N_Should_Instruct_Rover_Right_090_598()
        {
            rover2.OnSurface.CoordinateSystem.SetStartPosition("005 030 000");
            RoverInstruction actual_output = rover2.OnSurface.CoordinateSystem.CreateRoverCommand("015 030");
            actual_output._moveCommand.RotateDegrees.Should().Be(90);
            actual_output._moveCommand.RotateDirection.Should().Be(Rotation.Right);
            actual_output._moveCommand.MovementValue.Should().Be(598);
        }


        [Test]
        public void degree_of_latitude_should_be_60nm()
        {
            rover2.OnSurface.CoordinateSystem.SetStartPosition("85 10 0");
            RoverInstruction actual_output = rover2.OnSurface.CoordinateSystem.CreateRoverCommand("85 9");
            actual_output._moveCommand.RotateDegrees.Should().Be(-180);
            actual_output._moveCommand.RotateDirection.Should().Be(Rotation.Left);
            actual_output._moveCommand.MovementValue.Should().Be(69);
        }

        [Test]
        public void Start_Position_145W_086S_Facing_220_End_Position_010E_006N_Should_Instruct_Rover_Right_178_6883()
        {
            rover2.OnSurface.CoordinateSystem.SetStartPosition("-145 -86 220");
            RoverInstruction actual_output = rover2.OnSurface.CoordinateSystem.CreateRoverCommand("010 006");
            actual_output._moveCommand.RotateDegrees.Should().Be(178);
            actual_output._moveCommand.RotateDirection.Should().Be(Rotation.Right);
            actual_output._moveCommand.MovementValue.Should().Be(6883);

            //rover2.MoveRover(actual_output);
            //actual_output.SendRoverCommand();

        }

        [Test]
        public void Start_Position_30N_30E_Facing_000_End_Position_050N_30E_With_Limits_10N_10E_40N_40E_Should_Be_Null()
        {
            rover2.OnSurface.CoordinateSystem.SetStartPosition("30 30 000");
            rover2.OnSurface.CoordinateSystem.SetLimits("10 10 40 40");

            RoverInstruction actual_output = rover2.OnSurface.CoordinateSystem.CreateRoverCommand("50 30");

            actual_output.Should().BeNull();
        }

        [Test]
        public void Check_Rover_Moves_According_To_Cartesian_Instructions()
        {

            RoverInstruction actual_output = rover.OnSurface.CoordinateSystem.CreateRoverCommand("L");

            actual_output._moveCommand.RotateDegrees.Should().Be(90);
            actual_output._moveCommand.RotateDirection.Should().Be(Rotation.Left);
            actual_output._moveCommand.MovementValue.Should().Be(0);

            actual_output = rover.OnSurface.CoordinateSystem.CreateRoverCommand("R");

            actual_output._moveCommand.RotateDegrees.Should().Be(90);
            actual_output._moveCommand.RotateDirection.Should().Be(Rotation.Right);
            actual_output._moveCommand.MovementValue.Should().Be(0);

            actual_output = rover.OnSurface.CoordinateSystem.CreateRoverCommand("M");

            actual_output._moveCommand.RotateDegrees.Should().Be(0);
            actual_output._moveCommand.RotateDirection.Should().Be(Rotation.None);
            actual_output._moveCommand.MovementValue.Should().Be(1);

        }
    }
}