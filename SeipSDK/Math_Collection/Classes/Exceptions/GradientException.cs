using System;

namespace Math_Collection.Exceptions
{
    class GradientException : Exception
    {

        public GradientException()
        { }

        public GradientException(string message) : base(message)
        { }

        public GradientException(string message, Exception inner) : base(message, inner)
        { }
    }
}
