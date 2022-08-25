namespace HomeWork9
{
    public class HtmlParser : FileParser
    {
        public override string ParseFormat { get => ".html"; }
        public HtmlParser(string fileName) : base(fileName)
        {
        }
        public override void Open()
        {
            Console.WriteLine($"{nameof(HtmlParser)}: Файл {FileName} был открыт");
        }
        public override void Read()
        {
            Console.WriteLine($"{nameof(HtmlParser)}: Файл {FileName} был прочитан");
        }
        public override void Analize()
        {
            Console.WriteLine($"{nameof(HtmlParser)}: Файл {FileName} был проанализирован");
        }
        public override void Close()
        {
            Console.WriteLine($"{nameof(HtmlParser)}: Файл {FileName} был закрыт");
        }
    }
}