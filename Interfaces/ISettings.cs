namespace SimPranks
{
    using System.Collections.Generic;

    internal interface ISettings
    {
        IEnumerable<IApplicationOption> Options { get; set; }
    }
}