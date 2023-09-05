using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePatternLearning
{
    class Program
    {
        static void Main(string[] args)
        {
            Robot robot = new Robot(new WarMachineRobotState());
            robot.Upgrade();
            robot.Downgrade();
            robot.Downgrade();

            Console.Read();
        }
    }

    class Robot
    {
        public IRobotState State { get; set; }

        public Robot(IRobotState robotState)
        {
            State = robotState;
        }

        public void Upgrade()
        {
            State.Upgrade(this);
        }
        public void Downgrade()
        {
            State.Downgrade(this);
        }
    }

    //State Interface
    interface IRobotState
    {
        void Upgrade(Robot robot);
        void Downgrade(Robot robot);
    }

    //State A
    class RegularRobotState : IRobotState
    {
        public void Upgrade(Robot robot)
        {
            Console.WriteLine("Upgrade robot into War Machine");
            robot.State = new WarMachineRobotState();
        }

        public void Downgrade(Robot robot)
        {
            Console.WriteLine("It's still just a regular robot");
        }
    }

    //State B
    class WarMachineRobotState : IRobotState
    {
        public void Upgrade(Robot robot)
        {
            Console.WriteLine("It's time to upgrade War Machine into TERMINATOR");
            robot.State = new TerminatorRobotState();
        }

        public void Downgrade(Robot robot)
        {
            Console.WriteLine("No:( It was so cool. Now it's just a regular robot");
            robot.State = new RegularRobotState();
        }
    }

    //State C
    class TerminatorRobotState : IRobotState
    {
        public void Upgrade(Robot robot)
        {
            Console.WriteLine("TERMINATOR SO COOL THAT IT'S NO NEED TO UPGRADE");
        }

        public void Downgrade(Robot robot)
        {
            Console.WriteLine("I don't know why you downgrade TERMINATOR");
            robot.State = new WarMachineRobotState();
        }
    }
}
