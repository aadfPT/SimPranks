namespace SimPranks
{
    using System.Collections.Generic;

    internal interface ISettingsViewModel
    {
        IEnumerable<ApplicationOptionViewModel> Options { get; set; }
    }
}