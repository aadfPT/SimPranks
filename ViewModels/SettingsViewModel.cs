using System.Collections.Generic;
using System.Linq;

namespace SimPranks
{
    internal class SettingsViewModel : ISettings
    {
        internal SettingsViewModel(IEnumerable<IApplicationOption> pranks)
        {
            Options = pranks.Select(p => new ApplicationOptionViewModel(p.Active, p.Description)).ToList();
        }

        public IEnumerable<IApplicationOption> Options { get; set; }
    }
}