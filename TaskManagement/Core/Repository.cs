using TaskManagement.Core.Contracts;
using TaskManagement.Exceptions;
using TaskManagement.Models;
using TaskManagement.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Diagnostics.Metrics;

namespace TaskManagement.Core
{
    public class Repository : IRepository
    {
        private int _id;

        private readonly List<IMember> _members = new List<IMember>();
        private readonly List<ITeam> _teams = new List<ITeam>();
        private readonly List<ITask> _tasks = new List<ITask>();
        private readonly List<IBoard> _boards = new List<IBoard>();



        public void AddMemberToTeam(IMember member, ITeam team)
        {
            // TODO: Throw exception if member is already in the team

            team.AddMember(member);
        }

        public void AddTeam(ITeam team)
        {
            _teams.Add(team);
        }

        public void AddMember(IMember member)
        {
            _members.Add(member);
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

        public ITeam GetTeam(string teamName)
        {
            ITeam team = _teams.FirstOrDefault(u => u.Name.Equals(teamName, StringComparison.InvariantCultureIgnoreCase));
            if (team != null)
            {
                return team;
            }
            throw new EntityNotFoundException($"There is no team with name {team}!");
        }

        public IMember CreateMember(string member)
        {
            
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
            //this.Teams.AddActivity($"New team with name {name} was created.");
            return new Team(name);
        }

        public string ShowAllTeams()
        {
            return string.Join(", ", _teams.Select(team => team.Name));
        }

        public IBoard CreateBoard(string name)
        {
            return new Board(name);
        }

        public void AddBoard(IBoard board)
        {
            _boards.Add(board);
        }

        public void AddBoardToTeam(IBoard board, ITeam team)
        {
            throw new NotImplementedException();
        }

        public List<ITask> Tasks
        {
            get
            {
                return new List<ITask>(_tasks);
            }
        }

        public List<IBoard> Boards
        {
            get
            {
                return new List<IBoard>(_boards);
            }
        }
    }
}
