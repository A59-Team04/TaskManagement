using TaskManagement.Core.Contracts;
using TaskManagement.Exceptions;
using TaskManagement.Models;
using TaskManagement.Models.Contracts;
using System;
using System.Collections.Generic;

namespace TaskManagement.Core
{
    public class Repository : IRepository
    {
        private readonly IList<IMember> _members = new List<IMember>();


        public void AddMember(IMember member)
        {
            _members.Add(member);
        }

        public IList<IMember> Members
        {
            get => new List<IMember>(_members);
        }

        public IList<IMember> Member => new List<IMember>(_members);

        public IMember CreateMember(string member)
        {
            ValidateNameIsUnique(member, _members);
            return new Member(member);
        }

        private static void ValidateNameIsUnique<T>(string name, IEnumerable<T> lists) where T : INameable
        {
            if (lists.Any(m => m.Name == name))
            {
                throw new EntityAlreadyExistsException($"Member with name '{name}' already exists!");
            }
        }
    }
}
