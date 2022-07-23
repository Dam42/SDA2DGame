using FrogNinja.States;
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
            Debug.Log("Entered State");
        }

        public override void UpdateState()
        {
        }

        public override void ExitState()
        {
            Debug.Log("Exited State");
        }

        private void TransitionToGame()
        {
            myStateMachine.EnterState(new GameState(myStateMachine));
        }

        private void TransitionToMenu()
        {
            myStateMachine.EnterState(new MenuState(myStateMachine));
        }
    }

}
