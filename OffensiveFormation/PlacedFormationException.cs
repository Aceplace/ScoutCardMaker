using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffensiveFormation
{
    public class PlacedFormationException : Exception
    {
        public PlacedFormationException()
        {
        }

        public PlacedFormationException(string message) : base(message)
        {
        }

        public PlacedFormationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
