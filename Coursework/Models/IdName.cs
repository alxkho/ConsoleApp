namespace Coursework.Models
{
    public abstract class IdName
    {
        public string Name { get; set; }
        public int Id { get; set; }
        protected IdName(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}