using IdleRun.Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace IdleRun.StateMachine
{
    public class MenuState : IState
    {
        private GameState _gameState;
        private InputAction _startAction;

        public MenuState(GameState gameState, InputActionAsset actions)
        {
            _gameState = gameState;
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
            _gameState.ChangeState(new PlayState(_gameState, _startAction.actionMap.asset));
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