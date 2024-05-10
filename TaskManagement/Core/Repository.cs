﻿using TaskManagement.Core.Contracts;
using TaskManagement.Exceptions;
using TaskManagement.Models;
using TaskManagement.Models.Contracts;
using System;
using System.Collections.Generic;

namespace TaskManagement.Core
{
    public class Repository : IRepository
    {
        private readonly List<IMember> _members = new List<IMember>();
        private readonly List<ITeam> _teams = new List<ITeam>();


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
    }
}
