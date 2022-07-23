using FrogNinja.States;
using UnityEngine;
using FrogNinja.UI;

namespace FrogNinja.States
{
    public class GameState : BaseState
    {
        public GameState(StateMachine stateMachine)
        {
            Initialize(stateMachine);
        }

        public override void EnterState()
        {
            Debug.Log("Entered State");
            UIManager.Instance.ShowHUD();
        }

        public override void UpdateState()
        {
        }

        public override void ExitState()
        {
            Debug.Log("Exited State");
        }

        private void TransitionToMenu()
        {
            myStateMachine.EnterState(new MenuState(myStateMachine));
        }

        private void TransitionToLoose()
        {
            myStateMachine.EnterState(new LooseState(myStateMachine));
        }
    }

}

