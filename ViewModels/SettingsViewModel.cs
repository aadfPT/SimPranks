using System.Collections.Generic;
using System.Linq;

namespace SimPranks
{
    internal class SettingsViewModel : ISettings
    {
        internal SettingsViewModel(IEnumerable<PrankModel> pranks)
        {
            Options = pranks.Select(p => new ApplicationOptionViewModel(p.Active, p.Description)).ToList();
        }

        public IEnumerable<ApplicationOptionViewModel> Options { get; set; }
    }
}