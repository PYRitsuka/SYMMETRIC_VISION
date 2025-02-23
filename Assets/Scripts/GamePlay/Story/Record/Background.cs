using CsvHelper.Configuration.Attributes;

namespace GamePlay.Story.Record
{
    /// <summary>
    /// 背景Record类
    /// </summary>
    public class Background : Base
    {
        [Index(3)]
        public string Operation { get; set; }
        
        /// <summary>
        /// 操作的图片具体内容
        /// </summary>
        [Index(4)]
        public string Pattern { get; set; }
        
        [Index(5)]
        public string ScaleTransition { get; set; }
        
        [Index(6)]
        public string MoveTransition { get; set; }
        
        /// <summary>
        /// 入场离场
        /// </summary>
        [Index(7)]
        public string Transition { get; set; }
        
        /// <summary>
        /// 动作预设
        /// </summary>
        [Index(8)]
        public string Animation { get; set; }
        
        /// <summary>
        /// 特效滤镜
        /// </summary>
        [Index(9)] [NullValues("你是不是油饼 null")]
        public string Filter { get; set; }
    }
}