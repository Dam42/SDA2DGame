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
            Debug.Log("Entered State game");
            UIManager.Instance.ShowHUD();
            EventManager.PlayerFallenOff += EventManager_PlayerFallenOff;
        }

        public override void UpdateState()
        {
        }

        public override void ExitState()
        {
            EventManager.PlayerFallenOff -= EventManager_PlayerFallenOff;
            Debug.Log("Exited State game");
        }

        private void EventManager_PlayerFallenOff()
        {
            TransitionToLoose();
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

