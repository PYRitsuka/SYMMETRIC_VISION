using CsvHelper.Configuration.Attributes;

namespace GamePlay.Story.Record
{
    /// <summary>
    /// 滤镜Record类
    /// </summary>
    public class Filter : Base
    {
        [Index(3)]
        public string FilterName { get; set; }
    }
}