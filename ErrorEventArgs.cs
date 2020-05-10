namespace SimPranks
{
    using System;

    internal class ErrorEventArgs
    {
        internal Exception Exception;
        internal string Description;

        public ErrorEventArgs(Exception exception, string description)
        {
            Exception = exception;
            Description = description;
        }
    }
}