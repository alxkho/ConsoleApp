namespace HomeWork9
{
    public abstract class FileParser
    {
        public abstract string ParseFormat {get;}

        public readonly string FileName;

        const int Delay = 500;

        public FileParser(string fileName)
        {
            FileName = fileName;
        }

        abstract public void Read();

        abstract public void Open();

        abstract public void Analize();

        abstract public void Close();

        public virtual void Parse()
        {
            Thread.Sleep(Delay);
            Open();
            Thread.Sleep(Delay);
            Read();
            Thread.Sleep(Delay);
            Analize();
            Thread.Sleep(Delay);
            Close();
        }

        public static FileParser? GetParser(string fileName)
        {
            return Path.GetExtension(fileName) switch
            {
                ".xml" => new XmlParser(fileName),
                ".html" => new HtmlParser(fileName),
                ".rtf" => new RtfParser(fileName),
                _ => null,
            };
        }
    }
}