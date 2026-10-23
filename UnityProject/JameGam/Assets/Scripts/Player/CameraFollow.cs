using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player; 

    [Range(0f, 1f)]
    [SerializeField] float smoothTime = 0.15f;

    private Vector3 velocity = Vector3.zero;
    private float cameraZDepth;

    void Start()
    {
        cameraZDepth = transform.position.z;
    }

    void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(player.position.x, player.position.y, cameraZDepth);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
