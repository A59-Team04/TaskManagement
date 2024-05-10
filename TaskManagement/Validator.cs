using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Exceptions;

namespace TaskManagement
{
    public static class Validator
    {
        public static void ValidateIntRange(int value, int min, int max, string message)
        {
            if (value < min || value > max)
            {
                throw new InvalidUserInputException(message);
            }
        }
        public static void ValidateUniqueness(string name, List<string> Names, string message)
        {
            if (Names.Contains(name))
            {
                throw new ArgumentException(message);
            }
        }
        public static void ValidateUniqueness(int id, List<int> ids, string message)
        {
            if (ids.Contains(id))
            {
                throw new ArgumentException(message);
            }
        }

        //public static void ValidateName(string name, List<string> names, int nameLenght, int min, int max, string message)
        //{
        //    ValidateIntRange(nameLenght, min, max, message);
        //    ValidateUniqueness(name, names, message);
        //}
        // PROBABLY NOT NEEDED ?
    }
}
