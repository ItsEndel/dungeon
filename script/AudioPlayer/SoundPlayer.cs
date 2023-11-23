using Godot;

namespace Dungeon.Script.AudioPlayer;



/// <summary>
/// 音效播放器。<br/>
/// <br/>
/// 要按位置播放音效，请改用 <see cref="SoundPlayer2D"/> 。
/// </summary>
public partial class SoundPlayer : AudioStreamPlayer, ISoundPlayer
{
    // 功能变量 //
    /// <summary>
    /// 是否循环播放音效。若不循环播放，节点将在播放完成后自动释放。
    /// </summary>
    [Export]
    public bool Loop { get; set; }



    // 节点方法 //
    public override void _Ready()
    {
        Finished += OnFinished;
    }



    // 信号方法 //
    private void OnFinished() {
        if (!Loop) {
            QueueFree();
        }
    }
}
