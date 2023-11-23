using Dungeon.Script.AudioPlayer;
using Dungeon.Script.Scene;
using Godot;

namespace Dungeon.Scene;



/// <summary>
/// 游戏根节点，游戏主场景在此节点下
/// </summary>
[GlobalClass, Icon("res://icon/Game.svg")]
public partial class Game : Node2D, IScene {
    // 静态变量 //
    /// <summary>
    /// 游戏根节点实例。
    /// </summary>
    public static Game Root { get; private set; }

    /// <summary>
    /// 音乐播放器。
    /// </summary>
    public static MusicPlayer Music { get; private set; }

    /// <summary>
    /// 游戏主场景。
    /// </summary>
    public static IScene Scene {
        get => _scene;
        set => Game.Root.SetScene(value);
    }

    private static IScene _scene;



    // 节点变量 //
    /// <summary>
    /// 启动时载入的场景
    /// </summary>
    [Export]
    private PackedScene InitialScene;

    /// <summary>
    /// 音乐播放器节点
    /// </summary>
    [Export]
    private MusicPlayer MusicPlayer;



    // 节点方法 //
    public override void _Ready()
    {
        // 初始化静态变量
        Game.Root = this;
        Game.Music = this.MusicPlayer ?? new();

        // 初始化子节点
        if (!Game.Music.IsInsideTree()) {
            Game.Root.AddChild(Game.Music);
        }

        // 载入启动场景
        if (InitialScene.Instantiate() is IScene scene) {
            SetScene(scene);
        }
    }



    // 功能方法 //
    /// <summary>
    /// 设置游戏主场景。<br/>
    /// <br/>
    /// 此方法不会触发场景的 <c>Enter</c> / <c>Exit</c> 方法。
    /// </summary>
    /// <param name="scene">要设置的新场景</param>
    /// <param name="freeLastScene">是否释放旧场景</param>
    public void SetScene(IScene scene, bool freeLastScene = true) {
        // 清除原场景
        if (_scene is Node lastSceneNode) {
            RemoveChild(lastSceneNode);

            if (freeLastScene) {
                lastSceneNode.Free();
            }
        }

        _scene = null;

        // 设置新场景
        if (scene is Node sceneNode) {
            AddChild(sceneNode);
        }
    }
}
