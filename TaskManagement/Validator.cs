using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Exceptions;
using TaskManagement.Models;
using TaskManagement.Models.Contracts;

namespace TaskManagement
{
    public static class Validator
    {
        private static List<string> _allMemberNames = new List<string>();
        private static List<string> _allTeamNames = new List<string>();
        private static List<string> _allBoardNames = new List<string>();

        public static void ValidateIntRange(int value, int min, int max, string message)
        {
            if (value < min || value > max)
            {
                throw new InvalidUserInputException(message);
            }
        }
        public static void ValidateMemberNameUniqueness(string name, string message)
        {
            if (_allMemberNames.Contains(name))
            {
                throw new ArgumentException(message);
            }

            _allMemberNames.Add(name);
        }

        public static void ValidateTeamNameUniqueness(string name, string message)
        {
            if (_allTeamNames.Contains(name))
            {
                throw new ArgumentException(message);
            }

            _allTeamNames.Add(name);
        }        
        public static void ValidateBoardNameUniqueness(string name, string message)
        {
            if (_allBoardNames.Contains(name))
            {
                throw new ArgumentException(message);
            }

            _allBoardNames.Add(name);
        }

    }
}
