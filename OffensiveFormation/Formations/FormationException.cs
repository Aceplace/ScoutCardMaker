using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OffensiveFormation
{
    public class FormationException : Exception
    {
        public FormationException()
        {
        }

        public FormationException(string message) : base(message)
        {
        }

        public FormationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FormationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
