namespace HomeWork8.Attributes
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class AccessLevelAttribute : Attribute
    {
        public AccesLevelType Role { get; set; }

        public AccessLevelAttribute(AccesLevelType data)
        {
            Role = data;
        }
    }
}