
namespace FormulaOneConnect.Shared.Models;

public class Constructor
{
    public string ConstructorId { get; set; }
    public string Url { get; set; }
    public string Name { get; set; }
    public string Nationality { get; set; }
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
    public string Limit { get; set; }
    public string Offset { get; set; }
    public string Total { get; set; }
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
    public List<DriverStanding> DriverStandings { get; set; }
}

public class StandingsTable
{
    public string Season { get; set; }
    public List<Standings> StandingsLists { get; set; }
}



