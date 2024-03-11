using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneConnect.Shared.Models
{
    public class Location
    {
        public string Locality { get; set; }
        public string Country { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public string Text { get; set; }
    }

    public class Circuit
    {
        public string CircuitName { get; set; }
        public Location Location { get; set; }
        public string CircuitId { get; set; }
        public string Url { get; set; }
        public string Text { get; set; }
    }

    public class CircuitTable
    {
        public List<Circuit> Circuits { get; set; }
        public int Season { get; set; }
        public string Text { get; set; }
    }

    public class MRCircutData
    {
        public CircuitTable CircuitTable { get; set; }
        public string Xmlns { get; set; }
        public string Series { get; set; }
        public string Url { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
        public int Total { get; set; }
        public string Text { get; set; }
    }

    public class CircutResult
    {
        public MRCircutData MRData { get; set; }
    }
}
