/// <summary>
/// Game Framework
/// 
/// 创建者：Hurley
/// 创建时间：2025-11-16
/// 功能描述：
/// </summary>

using System;

using GameEngine;

namespace GameFramework.View.Fairygui
{
    public class FairyFormManager : IFormManager
    {
        public void Startup()
        {
            FairyFormHelper.Startup();

            InitUiSettings();

            FairyGUI.GRoot.inst.onSizeChanged.Add(InitUiSettings);
        }

        public void Shutdown()
        {
            FairyFormHelper.Shutdown();
        }

        public void Update()
        {
            FairyFormHelper.Update();
        }

        public Form CreateForm(Type viewType)
        {
            return new FairyForm(viewType);
        }

        public void AddGroup(string groupName, int level)
        {
        }

        public void RemoveGroup(string groupName)
        {
        }

        /// <summary>
        /// 初始化UI配置
        /// </summary>
        static void InitUiSettings()
        {
            // 普通屏幕
            FairyGUI.GRoot.inst.SetContentScaleFactor(
                NovaEngine.Environment.DesignResolutionWidth,
                NovaEngine.Environment.DesignResolutionHeight);

            // FairyGui相机背景颜色
            FairyGUI.StageCamera.main.backgroundColor = UnityEngine.Color.clear;

            UnityEngine.Object.DontDestroyOnLoad(FairyGUI.StageCamera.main);
        }
    }
}
