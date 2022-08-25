namespace HomeWork9
{
    public class RtfParser : FileParser
    {
        public override string ParseFormat { get => ".rtf"; }
        public RtfParser(string fileName) : base(fileName)
        {
        }
        public override void Open()
        {
            Console.WriteLine($"{nameof(RtfParser)}: Файл {FileName} был открыт");
        }
        public override void Read()
        {
            Console.WriteLine($"{nameof(RtfParser)}: Файл {FileName} был прочитан");
        }
        public override void Analize()
        {
            Console.WriteLine($"{nameof(RtfParser)}: Файл {FileName} был проанализирован");
        }
        public override void Close()
        {
            Console.WriteLine($"{nameof(RtfParser)}: Файл {FileName} был закрыт");
        }
    }
}