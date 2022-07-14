using FrogNinja.States;
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
            Debug.Log("Entered State");

            EventManager.EnterGameplay += EventManager_EnterGameplay;
        }

        private void EventManager_EnterGameplay()
        {
            TransitionToGame();
        }

        public override void UpdateState()
        {
            Debug.Log("Updated State");
        }

        public override void ExitState()
        {
            Debug.Log("Exited State");

            EventManager.EnterGameplay -= EventManager_EnterGameplay;
        }
        private void TransitionToGame()
        {
            myStateMachine.EnterState(new GameState(myStateMachine));
        }

    }
}

