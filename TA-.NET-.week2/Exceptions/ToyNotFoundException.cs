using System;

namespace TA_.NET_.week2.Exceptions
{
    class ToyNotFoundException : Exception
    {
        //Default constructor
        public ToyNotFoundException() : base() { }

        //Constructor with error message
        public ToyNotFoundException(string message) : base(message) { }

        //Construcor with error message and inner exception object
        public ToyNotFoundException(string message, Exception inner) : base(message, inner) { }
    }
}
