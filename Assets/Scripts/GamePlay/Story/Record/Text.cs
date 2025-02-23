using CsvHelper.Configuration.Attributes;

namespace GamePlay.Story.Record
{
    /// <summary>
    /// 文本Record类
    /// </summary>
    public class Text : Base
    {
        [Index(3)]
        public string DialogBoxPicture { get; set; }
        
        /// <summary>
        /// 初始不透明度a; 结束不透明度b; 耗时t秒;
        /// t=0则立即设定不透明度=b，无渐变效果
        /// </summary>
        [Index(4)]
        public string AlphaTransition { get; set; }
        
        [Index(5)]
        public string CharacterName { get; set; }
        
        [Index(6)]
        public string TextContent { get; set; }
        
        [Index(7)]
        public int TextSize { get; set; }
        
        [Index(8)] [NullValues("")]
        public string CharacterIcon { get; set; }
        
        /// <summary>
        /// 弹字速度, 每秒弹出x个字
        /// </summary>
        [Index(9)]
        public float TextSpeed { get; set; }
    }
}