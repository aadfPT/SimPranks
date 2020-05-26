namespace SimPranks
{
    internal class ApplicationOptionViewModel : IApplicationOption
    {
        public bool Active { get; set; }
        public string Description { get; set; }

        internal ApplicationOptionViewModel(bool active, string description)
        {
            Active = active;
            Description = description;
        }
    }
}