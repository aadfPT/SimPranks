using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimPranks
{
    using LowLevelInput.Hooks;

    internal class DuplicateLettersRandomlyPrankModel : PrankModel
    {
        private Random RandomGenerator { get; } = new Random();
        public override string Description => "Duplicates letters at random.";

        protected override bool FilterPayload(VirtualKeyCode key, KeyState state)
        {
            if (key < VirtualKeyCode.A || key > VirtualKeyCode.Z) return false;
            if (RandomGenerator.Next(0, 3) != 0) return false;
            InputSimulator.Keyboard.KeyPress((WindowsInput.Native.VirtualKeyCode)key);
            return false;
        }
    }
}
