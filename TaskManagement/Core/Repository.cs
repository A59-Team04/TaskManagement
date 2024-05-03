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
        private IList<IMember> _members = new List<IMember>(); 


        public void AddMember(IMember member)
        {
            this._members.Add(member);
        }

        public IList<IMember> Members
        {
            get => new List<IMember>(this._members);
        }

        public IList<IMember> Member => new List<IMember>(_members);

        public IMember CreateMember(string member)
        {
            return new Member(member);
        }

        public void ValidateMemberNameIsUnique(string name)
        {
            if (this._members.Any(m => m.Name == name))
            {
                throw new EntityAlreadyExistsException($"Member with name '{name}' already exists!");
            }
        }
    }
}
