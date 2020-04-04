using System.Collections.Generic;
using System.Linq;

namespace SimPranks
{
    internal class SettingsViewModel
    {
        internal SettingsViewModel(IEnumerable<PrankModel> pranks)
        {
            Options = pranks.Select(p => new ApplicationOptionViewModel(p.Active, p.Description)).ToList();
        }

        internal List<ApplicationOptionViewModel> Options { get; set; }
    }
}