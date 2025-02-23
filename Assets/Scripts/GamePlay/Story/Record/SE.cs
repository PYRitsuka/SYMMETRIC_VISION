using CsvHelper.Configuration.Attributes;

namespace GamePlay.Story.Record
{
    /// <summary>
    /// SE Record 类
    /// </summary>
    public class SE : Base
    {
        [Index(3)]
        public string SEName { get; set; }
        
        [Index(4)]
        public int Volume { get; set; }
        
    }
}