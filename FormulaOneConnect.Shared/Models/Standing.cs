
namespace FormulaOneConnect.Shared.Models;

public class Constructor
{
    public string ConstructorId { get; set; }
    public string Url { get; set; }
    public string Name { get; set; }
    public string Nationality { get; set; }
    public string Text { get; set; }

}

public class ConstructorStanding
{
    public Constructor Constructor { get; set; }
    public int Position { get; set; }
    public int PositionText { get; set; }
    public int Points { get; set; }
    public int Wins { get; set; }
    public string Text { get; set; }
}

public class DriverStanding
{
    public string Position { get; set; }
    public string PositionText { get; set; }
    public string Points { get; set; }
    public string Wins { get; set; }
    public Driver Driver { get; set; }
    public List<Constructor> Constructors { get; set; }
}

public class MRStandingData
{
    public string Xmlns { get; set; }
    public string Series { get; set; }
    public string Url { get; set; }
    public int Limit { get; set; }
    public int Offset { get; set; }
    public int Total { get; set; }
    public string Text { get; set; }
    public StandingsTable StandingsTable { get; set; }
}

public class StandingResult
{
    public MRStandingData MRData { get; set; }
}

public class Standings
{
    public string Season { get; set; }
    public string Round { get; set; }
}

public class StandingsTable
{
    public string Season { get; set; }
    public string Text { get; set; }
    public List<StandingsList> StandingsLists { get; set; }
}

public class StandingsList
{
    public List<ConstructorStanding> ConstructorStandings { get; set; }
    public List<DriverStanding> DriverStandings { get; set; }

    public int Season { get; set; }
    public int Round { get; set; }
    public string Text { get; set; }
}


