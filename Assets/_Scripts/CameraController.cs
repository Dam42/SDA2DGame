using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] [InspectorName("Follow: ")] private Transform player;
    private float tempPos;
    private Vector3 newCamPos;

    private void Awake()
    {
        newCamPos = new Vector3(0, 0, -10);
    }

    private void Update()
    {
        tempPos = transform.position.y;

        FollowPlayer();
    }

    private void FollowPlayer()
    {
        if (tempPos < player.position.y)
        {
            newCamPos.y = player.position.y;
            transform.localPosition = newCamPos;
        }
    }
}