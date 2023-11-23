using Godot;

namespace Dungeon.Script.AudioPlayer;



/// <summary>
/// 音乐播放器。会在播放完毕后自动重新播放。<br/>
/// <br/>
/// 在根节点中有实例。
/// </summary>
[GlobalClass]
public partial class MusicPlayer : AudioStreamPlayer {
    // 节点方法 //
    public override void _Ready()
    {
        Finished += OnFinished;
    }



    // 信号方法 //
    private void OnFinished() {
        Play();
    }
}
