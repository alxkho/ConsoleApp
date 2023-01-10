namespace Coursework
{
    public abstract class IdName
    {

        public string Name { get; set; }
        int Id { get; set; }
        protected IdName(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
