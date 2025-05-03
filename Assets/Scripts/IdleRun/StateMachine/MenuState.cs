using IdleRun.Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace IdleRun.StateMachine
{
    public class MenuState : IState
    {
        private GameStates _gameStates;
        private InputAction _startAction;

        public MenuState(GameStates gameStates, InputActionAsset actions)
        {
            _gameStates = gameStates;
            _startAction = actions.FindAction("UI/Submit");
        }

        public void Enter()
        {
            Debug.Log("ENTER Menu");
            _startAction.performed += OnStart;
            _startAction.Enable();
        }

        private void OnStart(InputAction.CallbackContext ctx)
        {
            _gameStates.ChangeState(new PlayState(_gameStates, _startAction.actionMap.asset));
        }

        public void Tick()
        {
        }

        public void Exit()
        {
            Debug.Log("EXIT Menu");
            _startAction.performed -= OnStart;
            _startAction.Disable();
        }
    }
}