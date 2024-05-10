using TaskManagement.Models.Contracts;

namespace TaskManagement.Core.Contracts
{
    public interface IRepository
    {
        IList<IMember> Members { get; }

        public IMember CreateMember(string member);
        public void AddMember(IMember member);

    }
}
