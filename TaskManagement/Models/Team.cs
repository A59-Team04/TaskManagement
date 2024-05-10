using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Models.Contracts;

namespace TaskManagement.Models
{
    internal class Team : ITeam
    {
        public const int MinNameLenght = 5;
        public const int MaxNameLenght = 15;
        public const string InvalidNameError = "Name must be between 5 and 15 characters long!";

        private string _name;
        private List<Member> _members;
        private List<Board> _board;
        private List<Team> _teams;
        private readonly List<ActivityHistory> _teamHistory = new List<ActivityHistory>();


        public Team(string name, List<Member> members, List<Board> board)
        {

        }

        public List<Member> Members
        {
            get
            {
                return _members;
            }
            //set with AddMember method
        }


        public List<Board> Boards
        {
            get
            {
                return _board;
            }
            // set with AddBoard method
        }

        public string Name
        {
            get
            {
                return _name;
            }
            private set
            {
                _name = value;
            }
        }

        public void ShowAllMembers()
        {
            foreach (Team in Teams)
            {
                Console.WriteLine($"{Team.Name}:");
                foreach (var member in _members)
                {
                    Console.WriteLine(member.Name);
                }
            }

        }

        public static void ViewTeamHistory()
        {
            foreach (Team team in _team)
            {
                Console.WriteLine(item.ViewHistory());
            }
        }

        public override void AddActivityToHistory(string desc)
        {
            this.teamHistory.Add(new ActivityHistory(desc));
        }
    }
}
