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
    }
}
