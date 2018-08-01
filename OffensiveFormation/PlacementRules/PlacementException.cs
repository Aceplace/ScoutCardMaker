using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffensiveFormation.PlacementRules
{
    public class PlacementException : Exception
    {
        public PlacementException()
        {
        }

        public PlacementException(string message) : base(message)
        {
        }

        public PlacementException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
