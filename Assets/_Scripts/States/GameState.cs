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
            EventManager.PlayerLost += EventManager_PlayerLost;
            EventManager.EnemyHitPlayer += EventManager_EnemyHitPlayer;
        }

        public override void UpdateState()
        {
        }

        public override void ExitState()
        {
            EventManager.PlayerLost -= EventManager_PlayerLost;
            EventManager.EnemyHitPlayer -= EventManager_EnemyHitPlayer;
            Debug.Log("Exited State game");
        }

        private void EventManager_PlayerLost()
        {
            TransitionToLoose();
        }

        private void EventManager_EnemyHitPlayer()
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

