using TaskManagement.Core.Contracts;
using TaskManagement.Exceptions;
using TaskManagement.Models;
using TaskManagement.Models.Contracts;
using System;
using System.Collections.Generic;
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

        public IMember CreateMember(string member)
        {
            Validator.ValidateMemberNameUniqueness(member, "Member with name '{0}' already exists!");

            return new Member(member);
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

            return new Team(name);
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
