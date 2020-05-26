namespace SimPranks
{
    using System;
    using System.Windows.Forms;
    using LowLevelInput.Hooks;

    internal class DriftMousePrankModel : PrankModel
    {
        private Random RandomGenerator { get; } = new Random();

        public override string Description => "Drifts the mouse at random.";

        protected override bool FilterPayload(VirtualKeyCode key, KeyState state)
        {
            if (key != VirtualKeyCode.Lbutton
                || RandomGenerator.Next(0, 8) != 0)
            {
                return false;
            }

            DriftMouse();
            return true;
        }

        private void DriftMouse()
        {
            var x = RandomGenerator.Next(0, SystemInformation.VirtualScreen.Width);
            var y = RandomGenerator.Next(0, SystemInformation.VirtualScreen.Height);
            while (Cursor.Position.X != x || Cursor.Position.Y != y)
            {
                if (Cursor.Position.X > x)
                {
                    InputSimulator.Mouse.MoveMouseBy(-1, 0);
                }
                else if(Cursor.Position.X < x)
                {
                    InputSimulator.Mouse.MoveMouseBy(1, 0);
                }
                if (Cursor.Position.Y > y)
                {
                    InputSimulator.Mouse.MoveMouseBy(0, -1);
                }
                else if(Cursor.Position.Y < y)
                {
                    InputSimulator.Mouse.MoveMouseBy(0, 1);
                }
            }
        }
    }
}