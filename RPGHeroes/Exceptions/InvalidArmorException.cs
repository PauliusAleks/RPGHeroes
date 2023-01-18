using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Exceptions
{
    /// <summary>
    /// Custom exception that allows setting a custom exception message.
    /// </summary>
    public class InvalidArmorException : Exception
    {
        public InvalidArmorException(string message) : base(message) { }
    }
}
