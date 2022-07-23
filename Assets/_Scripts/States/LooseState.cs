using FrogNinja.States;
using FrogNinja.UI;
using UnityEngine;

namespace FrogNinja.States
{
    public class LooseState : BaseState
    {
        public LooseState(StateMachine stateMachine)
        {
            Initialize(stateMachine);
        }

        public override void EnterState()
        {
            Debug.Log("Entered State lose");
            UIManager.Instance.ShowDeathScreen();
            EventManager.EnterGameplay += EventManager_EnterGameplay;
        }

        public override void UpdateState()
        {
        }

        private void EventManager_EnterGameplay()
        {
            TransitionToGame();
        }

        public override void ExitState()
        {
            Debug.Log("Exited State lose");
            EventManager.EnterGameplay -= EventManager_EnterGameplay;
        }

        private void TransitionToGame()
        {
            myStateMachine.EnterState(new GameState(myStateMachine));
        }

        public void TransitionToMenu()
        {
            myStateMachine.EnterState(new MenuState(myStateMachine));
        }
    }

}
