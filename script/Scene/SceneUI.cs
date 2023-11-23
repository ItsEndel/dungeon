using Godot;

namespace Dungeon.Script.Scene;



/// <summary>
/// 没有脚本的 UI 场景。<br/>
/// <br/>
/// 继承自 <c>Control</c> ，游戏场景请勿继承此类。
/// </summary>
[GlobalClass, Icon("res://icon/SceneUI.svg")]
public partial class SceneUI : Control, IScene {}
