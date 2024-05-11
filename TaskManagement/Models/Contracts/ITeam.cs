namespace TaskManagement.Models.Contracts
{
    public interface ITeam : INameable
    {
        List<IMember> Members { get; }
        void AddMember(IMember member);
        void RemoveMember(IMember member);

        List<IBoard> Boards { get; }
        void AddBoard(IBoard board);
        void RemoveBoard(IBoard board);

        void AddActivity(string description);
    }
}