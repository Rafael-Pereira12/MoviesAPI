using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Exceptions
{
    public class ResultNotFoundException : Exception
    {
        public ResultNotFoundException() : base("The record was not found")
        { }
    }
}
