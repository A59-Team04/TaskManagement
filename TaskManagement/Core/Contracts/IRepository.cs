using TaskManagement.Models.Contracts;

namespace TaskManagement.Core.Contracts
{
    public interface IRepository
    {
        List<IMember> Members { get; }
        public IMember CreateMember(string name);
        public void AddMemberToTeam(IMember member, ITeam team);

        List<ITeam> Teams { get; }
        public ITeam CreateTeam(string name);
        IMember GetMember(string personName);

        // TODO: Implement the same for Board
        // List<IBoard> Boards { get; }
        // public IBoard CreateBoard(string name);
        // public void AddBoardToTeam(IBoard board, ITeam team);
    }
}
