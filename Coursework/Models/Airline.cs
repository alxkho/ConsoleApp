using Coursework.Collections;

namespace Coursework.Models
{
    public class Airline : IdName
    {
        string Country { get; set; }
        AirlineType Type { get; set; }

        public Airline(int id, string name, string country, AirlineType type) : base(id, name)
        {
            Country = country;
            Type = type;
        }
    }

    public enum AirlineType
    {
        Continental,
        International,
        Charter,
    }
}
