using Godot;

namespace Dungeon.Script.Scene;



/// <summary>
/// 没有脚本的场景。<br/>
/// <br/>
/// 继承自 <c>Node</c> ，游戏场景请勿继承此类。
/// </summary>
[GlobalClass, Icon("res://icon/Scene.svg")]
public partial class Scene : Node, IScene {}
