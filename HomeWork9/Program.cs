using HomeWork9.MyDictionary;
using HomeWork9.Serialization;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Xml.Serialization;
using NewtonsoftJson = Newtonsoft.Json;

namespace HomeWork9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Dictionary
            /*var dict1 = new ApplicationDictionary<int, string>();
            dict1.Add(5, "str5");
            Console.WriteLine(dict1.GetByKey(3) ?? "Ключ не найден");

            var dict2 = new ApplicationDictionary<string, bool>();
            dict2.Add("str1", true);
            dict2.Add("str2", true);
            dict2.Add("str3", false);
            dict2.Remove("str2");
            var dict2Keys = dict2.GetAllKeys();
            dict2Keys.ForEach(r => Console.WriteLine(r));*/

            //serialization and deserialization
            try
            {
                Shape square = new(new Point(10, 10), 100, 100, "Квадрат");
                Shape triangle = new(new Point(20, 20), 100, 200, "Треугольник");
                Shape circle = new(new Point(30, 30), 50, 50, "Круг");

                var shapes = new List<Shape>() { square, triangle, circle };

                Console.Write("Введите название файла: ");
                var fileName = Console.ReadLine().Trim().ToLower();

                Console.Write("Введите расширение файла: ");
                var fileExtantion = Console.ReadLine().Trim().ToLower();

                if (fileExtantion != "json" && fileExtantion != "xml")
                    throw new Exception("Данный формат не поддерживается!");

                var file = $"{fileName}.{fileExtantion}";

                JsonSerializerOptions option = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic)
                };
                XmlSerializer xml = new XmlSerializer(typeof(List<Shape>));

                //serialization
                /* using (Stream stream = new FileStream(file, FileMode.OpenOrCreate))
                 {
                     if (fileExtantion == "json")
                     {
                         JsonSerializer.Serialize<List<Shape>>(stream, shapes, option);

                     }
                     else
                     {
                         xml.Serialize(stream, shapes);
                     }
                 }*/

                //Newtonsoft.Json
                using (StreamWriter writer = File.CreateText(file))
                {
                    if (fileExtantion == "json")
                    {
                        var json = NewtonsoftJson.JsonSerializer.CreateDefault();
                        json.Serialize(writer, shapes);
                    }
                }

                Console.WriteLine($"\nСериализация в файл {file} выполнена! Нажмите любую кнопку, чтобы выполнить десериализацию");
                Console.ReadKey();

                //deserialization
                /*using (Stream stream = new FileStream(file, FileMode.OpenOrCreate))
                {
                    if (fileExtantion == "json")
                    {

                        shapes = JsonSerializer.Deserialize<List<Shape>>(stream);
                    }
                    else
                    {
                        shapes = (List<Shape>)xml.Deserialize(stream);
                    }
                }*/

                //Newtonsoft.Json
                using (StreamReader reader = File.OpenText(file))
                {
                    if (fileExtantion == "json")
                    {
                        NewtonsoftJson.JsonSerializer json = new();
                        shapes = (List<Shape>)json.Deserialize(reader, typeof(List<Shape>));
                    }
                }

                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}