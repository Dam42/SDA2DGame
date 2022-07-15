using UnityEngine;

namespace FrogNinja.platforms
{
    public class BreakingPlatform : BasePlatform
    {
        private Animator anim;
        private BoxCollider2D platform;

        private void Awake()
        {
            anim = GetComponent<Animator>();
            platform = GetComponent<BoxCollider2D>();
        }

        protected override void HandleCollision(Collision2D collision)
        {
            platform.enabled = false;
            anim.CrossFade("break", 0, 0);
        }
    }

}
