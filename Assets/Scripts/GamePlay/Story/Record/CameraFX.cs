using CsvHelper.Configuration.Attributes;

namespace GamePlay.Story.Record
{
    /// <summary>
    /// 镜头Record类
    /// </summary>
    public class CameraFX : Base
    {
        [Index(3)]
        public string EffectName { get; set; }
    }
}