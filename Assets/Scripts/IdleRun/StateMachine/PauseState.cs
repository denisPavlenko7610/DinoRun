using UnityEngine;
using UnityEngine.InputSystem;

namespace IdleRun.StateMachine
{
    public class PauseState : IState
    {
        private readonly GameStates _machine;
        private readonly InputAction _resumeAction;
        private readonly InputAction _menuAction;

        public PauseState(GameStates machine, InputActionAsset actions)
        {
            _machine = machine;
            _resumeAction = actions.FindAction("Gameplay/Resume"); // например Escape или Gamepad Start
            _menuAction = actions.FindAction("UI/Submit"); // Enter для возвращения в меню
        }

        public void Enter()
        {
            Debug.Log("ENTER Pause");
            Time.timeScale = 0f; // Останавливаем физику, анимацию и т.п.
            _resumeAction.performed += OnResume;
            _menuAction.performed += OnBackToMenu;
            _resumeAction.Enable();
            _menuAction.Enable();
            // Здесь можно включить Overlay-панель паузы
        }

        private void OnResume(InputAction.CallbackContext ctx)
        {
            // Возвращаемся в PlayState
            _machine.ChangeState(new PlayState(_machine, _resumeAction.actionMap.asset));
        }

        private void OnBackToMenu(InputAction.CallbackContext ctx)
        {
            // Возвращаемся в MenuState
            _machine.ChangeState(new MenuState(_machine, _menuAction.actionMap.asset));
        }

        public void Tick()
        {
            // Можно тут обрабатывать прокрутку меню паузы, но логика чаще в UI-панели
        }

        public void Exit()
        {
            Debug.Log("EXIT Pause");
            Time.timeScale = 1f; // Восстанавливаем время
            _resumeAction.performed -= OnResume;
            _menuAction.performed -= OnBackToMenu;
            _resumeAction.Disable();
            _menuAction.Disable();
            // Скрываем Overlay-панель паузы
        }
    }
}