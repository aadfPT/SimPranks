namespace SimPranks
{
    using System;
    using LowLevelInput.Hooks;

    internal class LoveCommaPrankModel : PrankModel
    {
        public override string Description => "Replaces commas with hearths.";

        protected override bool FilterPayload(VirtualKeyCode key, KeyState state)
        {
            if (key != VirtualKeyCode.OemComma || state != KeyState.Down) return false;
            InputSimulator.Keyboard.TextEntry("♥");
            return true;
        }
    }
}