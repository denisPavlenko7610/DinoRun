using IdleRun.Core;

namespace IdleRun.UI
{
    public interface IUIManager : IGameService
    {
        void ShowPanel(string panelName);
        void HidePanel(string panelName);
    }
}