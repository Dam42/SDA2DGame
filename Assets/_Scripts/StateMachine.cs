using UnityEngine;

namespace FrogNinja.States
{
    public class StateMachine : MonoBehaviour
    {
        private BaseState _currentState;

        private void Awake()
        {
            EnterState(new MenuState(this));
        }

        private void Update()
        {
            _currentState.UpdateState();
        }

        public void EnterState(BaseState newState)
        {
            _currentState?.ExitState();

            _currentState = newState;

            _currentState.EnterState();
        }

        private void OnDestroy()
        {
            _currentState.ExitState();
        }
    }
}