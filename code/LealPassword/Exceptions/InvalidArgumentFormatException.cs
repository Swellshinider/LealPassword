using System;

namespace LealPassword.Exceptions
{
    internal sealed class InvalidArgumentFormatException : Exception
    {
        internal InvalidArgumentFormatException(string argument) 
            : base($"Missing character '-' before system argument '{argument}'") { }
    }
}