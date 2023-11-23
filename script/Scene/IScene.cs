using Dungeon.Scene;
using Godot;

namespace Dungeon.Script.Scene;



/// <summary>
/// 场景接口。所有游戏场景必须实现此接口并继承 <c>Node</c> 下的类。
/// </summary>
public interface IScene {
    // 功能方法 //
    /// <summary>
    /// 在节点树中向上寻找父场景。寻找失败时返回 <c>null</c> 。
    /// </summary>
    IScene GetParentScene() {
        // 自身必须继承 Node 下的类
        if (this is not Node) {
            return null;
        }

        Node _this = this as Node;

        // 寻找父场景
        Node parent = _this.GetParent();
        while (parent is not IScene) {
            // 若无父节点，停止寻找
            if (parent is null) {
                break;
            }

            parent = parent.GetParent();
        }

        // 返回结果
        if (parent is IScene scene) {
            return scene;
        }

        return null;
    }

    /// <summary>
    /// 将当前场景切换为其他场景。<br/>
    /// <br/>
    /// 切换失败时无效果。
    /// </summary>
    /// <param name="scene">切换到的场景示例</param>
    /// <param name="data">向切换到的场景传递的数据</param>
    /// <param name="freeSelf">场景切换后是否释放自我</param>
    void Switch(IScene scene, ISceneData data, bool freeSelf = true) {
        // 自身和指定场景必须继承 Node 下的类
        if (this is not Node || scene is not Node) {
            return;
        }

        Node _this = this as Node;
        Node _scene = scene as Node;

        // 获取父场景
        IScene parent = GetParentScene();

        // 根据父场景类型切换场景
        if (parent is null) {
            foreach (Node child in _this.GetChildren()) {
                child.QueueFree();
            }

            _this.ReplaceBy(_scene);
        } else if (parent is Game game) {
            game.SetScene(scene);
        } else if (parent is Node parentNode) {
            parentNode.RemoveChild(_this);
            parentNode.AddChild(_scene);
        }

        // 触发场景的进入和退出方法
        this.Exit();
        scene.Enter(data);

        // 排队释放自我
        if (freeSelf) {
            _this.QueueFree();
        }
    }



    // 继承方法 //
    /// <summary>
    /// 进入此场景时触发的方法
    /// </summary>
    void Enter(ISceneData data) {}

    /// <summary>
    /// 退出此场景时触发的方法
    /// </summary>
    void Exit() {}
}
