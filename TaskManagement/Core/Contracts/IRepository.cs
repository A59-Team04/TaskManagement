using TaskManagement.Models.Contracts;

namespace TaskManagement.Core.Contracts
{
    public interface IRepository
    {
        List<IMember> Members { get; }
        public IMember CreateMember(string name);
        public void AddMember(IMember member);
        public void AddMemberToTeam(IMember member, ITeam team);
        IMember GetMember(string personName);

        List<ITeam> Teams { get; }
        public ITeam CreateTeam(string name);
        public void AddTeam(ITeam team); 
        ITeam GetTeam(string personName);

        // TODO: Implement the same for Board
        List<IBoard> Boards { get; }
        public IBoard CreateBoard(string name);
        public void AddBoard(IBoard board);
        public void AddBoardToTeam(IBoard board, ITeam team);
    }
}
