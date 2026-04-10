using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Exceptions
{
    class NotFoudException : Exception
    {
        public NotFoudException(string message) : base(message) { }
    }
}
