namespace Coursework
{
    public class Airport : IdName
    {
        string Country { get; set; }
        string City { get; set; }
        string Size { get; set; }
        public Airport(int id, string name, string city, string country) : base(id, name)
        {
            Country = country;
            City = city;
        }
    }
}