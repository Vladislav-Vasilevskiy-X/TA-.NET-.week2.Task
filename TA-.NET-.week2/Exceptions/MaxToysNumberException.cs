using System;

namespace TA_.NET_.week2.Exceptions
{
    class MaxToysNumberException : Exception
    {
        //Default constructor
        public MaxToysNumberException() : base() { }

        //Constructor with error message
        public MaxToysNumberException(string message) : base(message) { }

        //Construcor with error message and inner exception object
        public MaxToysNumberException(string message, Exception inner) : base(message, inner) { }
    }
}
