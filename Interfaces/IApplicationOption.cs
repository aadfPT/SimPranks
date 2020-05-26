namespace SimPranks
{
    internal interface IApplicationOption
    {
        bool Active { get; }
        string Description { get; }
    }
}