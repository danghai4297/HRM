using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Utilities.Exceptions
{
    public class HRMException : Exception
    {
        public HRMException()
        {

        }

        public HRMException(string message) : base(message)
        {

        }
        public HRMException(string message, Exception inner): base(message, inner)
        {

        }
    }
}
