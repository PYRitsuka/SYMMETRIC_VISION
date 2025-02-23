using CsvHelper.Configuration.Attributes;

namespace GamePlay.Story.Record
{
    /// <summary>
    /// BGM Record 类
    /// </summary>
    public class BGM : Base
    {
        [Index(3)]
        public string MusicName { get; set; }
        
        [Index(4)] [BooleanFalseValues("不循环")] [BooleanTrueValues("循环")]
        public bool IsLoop { get; set; }
        
        [Index(5)]
        public string VolumeTransition { get; set; }
    }
}