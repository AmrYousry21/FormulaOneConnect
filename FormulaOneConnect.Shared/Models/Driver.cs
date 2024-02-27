
namespace FormulaOneConnect.Shared.Models
{
    public class Driver
    {
        public string DriverId { get; set; }
        public string PermanentNumber { get; set; }
        public string Code { get; set; }
        public string Url { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string DateOfBirth { get; set; }
        public string Nationality { get; set; }
    }

    public class DriverTable
    {
        public string CircuitId { get; set; }
        public string ConstructorId { get; set; }
        public List<Driver> Drivers { get; set; }
    }

    public class MRDriverData
    {
        public string Xmlns { get; set; }
        public string Series { get; set; }
        public string Url { get; set; }
        public string Limit { get; set; }
        public string Offset { get; set; }
        public string Total { get; set; }
        public DriverTable DriverTable { get; set; }
    }

    public class DriverResult
    {
        public MRDriverData MRData { get; set; }
    }
}
