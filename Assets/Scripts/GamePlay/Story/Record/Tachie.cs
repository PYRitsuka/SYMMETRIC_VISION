using CsvHelper.Configuration.Attributes;

namespace GamePlay.Story.Record
{
    /// <summary>
    /// 立绘Record类
    /// </summary>
    public class Tachie : Base
    {
        [Index(3)]
        public string Operation { get; set; }
        
        /// <summary>
        /// 操作的图片/具体内容
        /// </summary>
        [Index(4)]
        public string Pattern { get; set; }
        
        [Index(5)]
        public string ScaleTransition { get; set; }
        
        [Index(6)]
        public string MoveTransition { get; set; }
        
        [Index(7)]
        public string AlphaTransition { get; set; }
        
        [Index(8)]
        public string Animation { get; set; }
        
        [Index(9)]
        public string Color { get; set; }
    }
}