namespace HomeWork8.Attributes
{
    public class AttributeProgram
    {
        public static void Start()
        {
            Director director = new Director();
            Manager manager = new Manager();
            Worker worker = new Worker();

            GetAccess(director, AccesLevelType.High);
            GetAccess(director, AccesLevelType.Low);
            GetAccess(manager, AccesLevelType.High);
            GetAccess(worker, AccesLevelType.Average);
            GetAccess(worker, AccesLevelType.Low);
        }

        static void GetAccess(Employee employee, AccesLevelType acces)
        {
            var type = employee.GetType();
            var attr = (AccessLevelAttribute)Attribute.GetCustomAttribute(type, typeof(AccessLevelAttribute));
            var role = attr.Role;

            if (role <= acces)
                Console.WriteLine("Доступ к данным разрешен");
            else
                Console.WriteLine("Доступ к данным запрещен");
        }
    }
}