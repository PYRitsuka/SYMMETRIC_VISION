using CsvHelper.Configuration.Attributes;

namespace GamePlay.Story.Record
{
    /// <summary>
    /// Record基类
    /// </summary>
    public class Base
    {
        [Index(0)]
        public string Indicator { get; set; }
        
        [Index(1)]
        public string Condition { get; set; }
        
        [Index(2)] [BooleanFalseValues("串行")] [BooleanTrueValues("并行")]
        public bool IsParallel { get; set; }
    }
}