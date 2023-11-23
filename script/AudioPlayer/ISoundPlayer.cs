
namespace Dungeon.Script.AudioPlayer;



/// <summary>
/// 音效播放器必须实现的接口。
/// </summary>
public interface ISoundPlayer {
    // 功能变量 //
    /// <summary>
    /// 是否循环播放音效。若不循环播放，节点将在播放完成后自动释放。
    /// </summary>
    bool Loop { get; set; }
}
