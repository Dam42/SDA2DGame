using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody2D player;

    private void Update()
    {
        var state = GetState();

        if (state == _currentState) return;
        anim.CrossFade(state, 0, 0);
        _currentState = state;
    }

    private int GetState()
    {
        if (player.velocity.y > 0) return Jump;
        if (player.velocity.y < 0) return Fall;
        if (player.velocity.x != 0 && player.velocity.y == 0) return Run;
        return Idle;
    }

    #region Cached Properties

    private int _currentState;

    private static readonly int Idle = Animator.StringToHash("Idle");
    private static readonly int Run = Animator.StringToHash("Run");
    private static readonly int Jump = Animator.StringToHash("Jump");
    private static readonly int Fall = Animator.StringToHash("Fall");

    #endregion Cached Properties
}