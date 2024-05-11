using TaskManagement.Core.Contracts;
using TaskManagement.Exceptions;
using TaskManagement.Models;
using TaskManagement.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace TaskManagement.Core
{
    public class Repository : IRepository
    {
        private int _id;

        private readonly List<IMember> _members = new List<IMember>();
        private readonly List<ITeam> _teams = new List<ITeam>();
        private readonly List<ITask> _tasks = new List<ITask>();    



        public void AddMemberToTeam(IMember member, ITeam team)
        {
            // TODO: Throw exception if member is already in the team

            team.AddMember(member);
        }

        public List<IMember> Members
        {
            get
            {
                return new List<IMember>(_members);
            }
        }
        public IMember GetMember(string memberName)
        {
            IMember member = _members.FirstOrDefault(u => u.Name.Equals(memberName, StringComparison.InvariantCultureIgnoreCase));
            if (member != null)
            {
                return member;
            }
            throw new EntityNotFoundException($"There is no user with username {memberName}!");
        }

        public IMember CreateMember(string member)
        {
            Validator.ValidateMemberNameUniqueness(member, "Member with name '{0}' already exists!");

            return new Member(member);
        }

        public string ShowAllPeople()
        {
            return string.Join(", ", _members.Select(member => member.Name));
        }


        public List<ITeam> Teams
        {
            get
            {
                return new List<ITeam>(_teams);
            }
        }

        public ITeam CreateTeam(string name)
        {
            Validator.ValidateTeamNameUniqueness(name, "Team with name '{0}' already exists!");
            //this.Teams.AddActivity($"New team with name {name} was created.");
            return new Team(name);
        }

        public string ShowAllTeams()
        {
            return string.Join(", ", _teams.Select(team => team.Name));
        }

        public List<ITask> Tasks
        {
            get
            {
                return new List<ITask>(_tasks);
            }
        }
    }
}
