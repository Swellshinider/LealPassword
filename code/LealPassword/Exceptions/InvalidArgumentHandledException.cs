using System;

namespace LealPassword.Exceptions
{
    internal sealed class InvalidArgumentHandledException : Exception
    {
        internal InvalidArgumentHandledException(string argument): 
            base($"Invalid argument handled, the argument '{argument}' is not recognized as a system argument") { }
    }
}