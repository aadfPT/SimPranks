namespace SimPranks
{
    internal class ApplicationOptionViewModel
    {
        internal bool Active { get; set; }
        internal string Description { get; set; }

        internal ApplicationOptionViewModel(bool active, string description)
        {
            Active = active;
            Description = description;
        }
    }
}