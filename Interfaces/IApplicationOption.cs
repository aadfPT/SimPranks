namespace SimPranks
{
    internal interface IApplicationOption
    {
        bool Active { get; set; }
        string Description { get; set; }
    }
}