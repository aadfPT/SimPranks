using System;
using System.Text;
using System.Threading.Tasks;
using LowLevelInput.Hooks;
using LowLevelInput.WindowsHooks;
using WindowsInput;

namespace SimPranks
{
    using System.ComponentModel;

    /// <summary>
    /// Inherit this class to set up new Pranks.
    /// </summary>
    internal abstract class PrankModel : IComparable<PrankModel>
    {
        internal abstract string Description { get; }

        internal bool Active { get; set; } = true;
        internal static bool ExecutingPayload { get; set; }

        protected static readonly InputSimulator InputSimulator = new InputSimulator();

        /// <summary>
        /// Allows intercepting of key events and blocking it if desired.
        /// </summary>
        /// <param name="key">Key associated.</param>
        /// <param name="state">State of the key.</param>
        /// <returns>Return false to allow key event, true to filter it.</returns>
        protected abstract bool FilterPayload(VirtualKeyCode key, KeyState state);

        internal WindowsHookFilter.WindowsHookFilterEventHandler FilterEventHandler
        {
            get
            {
                return (key, state) =>
                {
                    if (!Active
                        || ExecutingPayload)
                    {
                        return false;
                    }

                    try
                    {
                        ExecutingPayload = true;
                        var result = FilterPayload(key, state);
                        ExecutingPayload = false;
                        return result;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                };
            }
        }

        public int CompareTo(PrankModel other)
        {
            return Description.CompareTo(other.Description);
        }
    }
}
