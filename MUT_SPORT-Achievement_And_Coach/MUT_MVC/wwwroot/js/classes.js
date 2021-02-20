class Tournament
{
    
    set tname(tname)
    {
        this.tname = tname;
    }

    set setTournamentType(tType)
    {
        this.tType = tType;
    }

    set StartDate(startDate)
    {
        this.startDate = startDate;
    }

    set NumberOfTeams(numOfTeams)
    {
        this.numOfTeams = numOfTeams;
    }

    get tname()
    {
        return tname;
    }

    get TournamentType()
    {
        return tType;
    }

    get StartDate()
    {
        return startDate;
    }

    get NumberOfTeams()
    {
        return numfTeams;
    }
} 

class Team
{
    set teamName(teamName)
    {
        this.teamName = teamName;
    }

    get teamName()
    {
        return teamName;
    }
}

class Fixture
{
    set fixture(fixtureName)
    {
        this.fixtureName = fixtureName;
    }

    get fixture()
    {
        return fixtureName;
    }
}