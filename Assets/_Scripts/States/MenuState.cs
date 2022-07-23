using FrogNinja.States;
using FrogNinja.UI;
using UnityEngine;

namespace FrogNinja.States
{
    public class MenuState : BaseState
    {
        public MenuState(StateMachine stateMachine)
        {
            Initialize(stateMachine);
        }

        public override void EnterState()
        {
            Debug.Log("Entered State menu");
            UIManager.Instance.ShowMainMenu();
            EventManager.EnterGameplay += EventManager_EnterGameplay;
        }

        private void EventManager_EnterGameplay()
        {
            TransitionToGame();
        }

        public override void UpdateState()
        {
        }

        public override void ExitState()
        {
            Debug.Log("Exited State menu");

            EventManager.EnterGameplay -= EventManager_EnterGameplay;
        }
        private void TransitionToGame()
        {
            myStateMachine.EnterState(new GameState(myStateMachine));
        }

    }
}

