namespace SimPranks
{
    using System.Collections.Generic;

    internal interface ISettings
    {
        IEnumerable<ApplicationOptionViewModel> Options { get; set; }
    }
}