using CsvHelper.Configuration.Attributes;

namespace GamePlay.Story.Record
{
    /// <summary>
    /// 程序Record类
    /// </summary>
    public class Program : Base
    {
        [Index(3)]
        public string Command { get; set; }
    }
}