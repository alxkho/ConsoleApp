namespace HomeWork9
{
    public class XmlParser : FileParser
    {
        public override string ParseFormat { get => ".xml"; }
        public XmlParser(string fileName) : base(fileName)
        {
        }
        public override void Open()
        {
            Console.WriteLine($"{nameof(XmlParser)}: Файл {FileName} был открыт");
        }
        public override void Read()
        {
            Console.WriteLine($"{nameof(XmlParser)}: Файл {FileName} был прочитан");
        }
        public override void Analize()
        {
            Console.WriteLine($"{nameof(XmlParser)}: Файл {FileName} был проанализирован");
        }
        public override void Close()
        {
            Console.WriteLine($"{nameof(XmlParser)}: Файл {FileName} был закрыт");
        }
    }
}