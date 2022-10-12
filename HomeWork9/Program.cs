using HomeWork9.MyDictionary;

namespace HomeWork9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Dictionary
            var dict1 = new ApplicationDictionary<int, string>();
            dict1.Add(5, "str5");
            Console.WriteLine(dict1.GetByKey(3) ?? "Ключ не найден");

            var dict2 = new ApplicationDictionary<string, bool>();
            dict2.Add("str1", true);
            dict2.Add("str2", true);
            dict2.Add("str3", false);
            dict2.Remove("str2");
            var dict2Keys = dict2.GetAllKeys();
            dict2Keys.ForEach(r => Console.WriteLine(r));

            //serialization/deserialization

            Console.ReadLine();
        }
    }
}