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
        internal event EventHandler<ErrorEventArgs> ErrorSubscriber;
        internal abstract string Description { get; }

        internal bool Active { get; set; } = true;
        protected static bool ExecutingPayload { get; set; }

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
                    var result = false;
                    try
                    {
                        if (Active && !ExecutingPayload)
                        {
                            ExecutingPayload = true;
                            result = FilterPayload(key, state);
                        }
                    }
                    catch (Exception x)
                    {
                        var args = new ErrorEventArgs(x, x.Message);
                        ErrorSubscriber?.Invoke(this, args);
                    }
                    finally
                    {
                        ExecutingPayload = false;
                    }
                    return result;
                };
            }
        }

        public int CompareTo(PrankModel other)
        {
            return Description.CompareTo(other.Description);
        }
    }
}
