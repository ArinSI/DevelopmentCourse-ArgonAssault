using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform; // Reference to the player
    public float followSpeed = 5f;    // Speed at which the camera follows the player
    private Vector3 offset;           // Offset between the camera and the player
    private bool isFollowingPlayer = true;  // Determines if the camera should follow the player

    // Start is called before the first frame update
    void Start()
    {
        if (playerTransform != null)
        {
            // Calculate the initial offset between the camera and the player
            offset = transform.position - playerTransform.position;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (isFollowingPlayer)
        {
            FollowPlayer();
        }
    }

    public void FollowPlayer()
    {
        if (playerTransform != null)
        {
            // Smoothly follow the player using the offset
            Vector3 targetPosition = playerTransform.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }

    public void UnfollowPlayer()
    {
        isFollowingPlayer = false; // Stops the camera from following the player
    }

    public void StartFollowingPlayer()
    {
        isFollowingPlayer = true; // Resumes following the player
    }

    public void Shake(float duration, float magnitude)
    {
        StartCoroutine(ShakeCoroutine(duration, magnitude));
    }

    private IEnumerator ShakeCoroutine(float duration, float magnitude)
    {
        Vector3 originalPosition = transform.localPosition; // Store the camera's original position

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            // Generate random positions within a unit sphere and multiply by magnitude
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            // Apply the shake effect
            transform.localPosition = new Vector3(originalPosition.x + x, originalPosition.y + y, originalPosition.z);

            elapsed += Time.deltaTime;

            // Wait until the next frame
            yield return null;
        }

        // Reset the camera to its original position
        transform.localPosition = originalPosition;
    }
}
