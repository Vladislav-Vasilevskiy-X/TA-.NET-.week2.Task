using System;

namespace TA_.NET_.week2.Exceptions
{
    class DeletingUsableToyException : Exception
    {
        //Default constructor
        public DeletingUsableToyException() : base() { }

        //Constructor with error message
        public DeletingUsableToyException(string message) : base(message) { }

        //Construcor with error message and inner exception object
        public DeletingUsableToyException(string message, Exception inner) : base(message, inner) { }
    }
}
