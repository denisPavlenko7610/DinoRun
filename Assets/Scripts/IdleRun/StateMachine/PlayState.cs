using IdleRun.Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace IdleRun.StateMachine
{
    public class PlayState : IState
    {
        private readonly GameState _machine;
        private readonly InputAction _pauseAction;

        public PlayState(GameState machine, InputActionAsset actions)
        {
            _machine = machine;
            _pauseAction = actions.FindAction("Gameplay/Pause");
        }

        public void Enter()
        {
            Debug.Log("ENTER Play");
            _pauseAction.performed += OnPause;
            _pauseAction.Enable();
            // здесь инициализация игрового процесса
        }

        private void OnPause(InputAction.CallbackContext ctx)
        {
            // Переходим в состояние паузы
            _machine.ChangeState(new PauseState(_machine, _pauseAction.actionMap.asset));
        }

        public void Tick()
        {
            // основная игровая логика
        }

        public void Exit()
        {
            Debug.Log("EXIT Play");
            _pauseAction.performed -= OnPause;
            _pauseAction.Disable();
            // при выходе из PlayState ничего не делаем с Time.timeScale — это делает PauseState.Exit
        }
    }
}