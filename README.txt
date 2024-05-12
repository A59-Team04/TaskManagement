To create a team: CreateTeam <name>

To create a board to a team: CreateBoard <board name> <team name>

To create a member: CreateMember <name>

To add a member to a team: AddMemberToTeam <member name> <team name>

To show boards in a team: ShowTeamBorads <team name>

To show a member: ShowMembers

To show members in a team: ShowTeamMembers <team name>


Sample input:

CreateMember Gosho
CreateMember Rado
CreateTeam Avengers
CreateBoard Plannig Avengers
CreateBoard Master Avengers
AddMemberToTeam Gosho Avengers
AddMemberToTeam Rado Avengers
AddMemberToTeam Viktor Avengers
ShowTeamMembers Avengers
ShowTeamBoards Avengers


Expected sample output:


Member with name 'Gosho' was created!
---------------------------
Name must be between 5 and 15 characters long!
---------------------------
New team with name Avengers was created.
---------------------------
Board 'Plannig' created in team 'Avengers' successfully!
---------------------------
Board 'Master' created in team 'Avengers' successfully!
---------------------------
Member 'Gosho' added to team 'Avengers' successfully
---------------------------
There is no user with username Rado!
---------------------------
There is no user with username Viktor!
---------------------------
--Team: Avengers--
    Members:
      1. Gosho
---------------------------
--Team: Avengers--
    Boards:
      1. Plannig
      2. Master
---------------------------


