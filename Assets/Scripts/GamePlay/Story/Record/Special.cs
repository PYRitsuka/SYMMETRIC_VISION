using CsvHelper.Configuration.Attributes;

namespace GamePlay.Story.Record
{
    public class Special : Base
    {
        [Index(3)] public string Function { get; set; }
        [Index(4)] public string Content { get; set; }
    }
}