using Godot;

namespace Dungeon.Script.Scene;



/// <summary>
/// 没有脚本的 2D 场景。<br/>
/// <br/>
/// 继承自 <c>Node2D</c> ，游戏场景请勿继承此类。
/// </summary>
[GlobalClass, Icon("res://icon/Scene2D.svg")]
public partial class Scene2D : Node2D, IScene {}
