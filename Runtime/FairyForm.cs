/// <summary>
/// Game Framework
/// 
/// 创建者：Hurley
/// 创建时间：2025-11-16
/// 功能描述：
/// </summary>

using GameEngine;

using SystemType = System.Type;

using FairyGComponent = FairyGUI.GComponent;

using UniTask = Cysharp.Threading.Tasks.UniTask;

namespace Game.Module.View.Fairygui
{
    /// <summary>
    /// 基于FairyGui封装的窗口对象类
    /// </summary>
    public sealed class FairyForm : Form
    {
        /// <summary>
        /// 视图对象挂载的窗口实例
        /// </summary>
        private BaseWindow _window;

        /// <summary>
        /// 窗口设置相关数据结构
        /// </summary>
        private WindowSettings _settings;

        /// <summary>
        /// 视图对象的模型根节点
        /// </summary>
        public FairyGComponent ContentPane => _window?.contentPane;

        /// <summary>
        /// 窗口根节点对象实例
        /// </summary>
        public override object Root => _window?.contentPane;

        internal FairyForm(SystemType viewType) : base(viewType)
        {
            _settings = new WindowSettings(viewType?.Name);
        }

        ~FairyForm()
        { }

        /// <summary>
        /// 窗口实例的加载接口函数
        /// </summary>
        protected override sealed async UniTask Load()
        {
            _window = new BaseWindow(_settings);
            _window.Show();

            await _window.WaitLoadAsync();

            if (null != _window.contentPane)
            {
                _isLoaded = true;
                _window.contentPane.visible = false;

                // 编辑器下显示名字
                if (NovaEngine.Environment.IsDevelopmentState())
                {
                    _window.gameObjectName = $"{_viewType.Name}(Pkg:{_settings.pkgName},Com:{_settings.comName})";
                }
            }
        }

        /// <summary>
        /// 窗口实例的卸载接口函数
        /// </summary>
        protected override sealed void Unload()
        {
            _window?.Dispose();
            _window = null;

            _isLoaded = false;
        }

        /// <summary>
        /// 窗口实例的显示接口函数
        /// </summary>
        protected override sealed void Show()
        {
            // if (null != ContentPane) ContentPane.visible = true;

            _window.ShowContentPane();
        }

        /// <summary>
        /// 窗口实例的隐藏接口函数
        /// </summary>
        protected override sealed void Hide()
        {
            Debugger.Throw<System.NotImplementedException>();
        }
    }
}
