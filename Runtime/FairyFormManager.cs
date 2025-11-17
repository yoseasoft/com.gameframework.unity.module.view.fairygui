/// <summary>
/// Game Framework
/// 
/// 创建者：Hurley
/// 创建时间：2025-11-16
/// 功能描述：
/// </summary>

using GameEngine;

using SystemType = System.Type;

namespace Game.Module.View.Fairygui
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

        public Form CreateForm(SystemType viewType)
        {
            return new FairyForm(viewType);
        }
    }
}
