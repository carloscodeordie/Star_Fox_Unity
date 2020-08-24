using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{

    [Header("General")]
    [Tooltip("In meters per second")][SerializeField] float xSpeed = 8f;
    [Tooltip("In meters per second")] [SerializeField] float ySpeed = 8f;
    [Tooltip("In meters")] [SerializeField] float xMaximumMovement = 6f;
    [Tooltip("In meters")] [SerializeField] float yMaximumMovement = 4f;

    [Header("Screen position based")]
    [SerializeField] float positionPitchFactor = -3f;
    [SerializeField] float positionYawlFactor = 3f;
    [Header("Control throw parameters")]
    [SerializeField] float controlRollFactor = -20f;
    [SerializeField] float controlPitchFactor = -15f;

    float xThrow;
    float yThrow;
    bool isControlEnabled = true;

// Detect collisions
    private void OnCollisionEnter(Collision collision)
    {
        print("Collision");
    }

    // Update is called once per frame
    void Update()
    {
        if (isControlEnabled)
        {
            MoveHorizontal();
            MoveVertical();
            ProcessRotation();
        }
    }

    private void MoveHorizontal()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float xNewPosition = transform.localPosition.x + xOffset;
        float xClampedPosition = Mathf.Clamp(xNewPosition, -xMaximumMovement, xMaximumMovement);
        transform.localPosition = new Vector3(xClampedPosition, transform.localPosition.y, transform.localPosition.z);
    }

    private void MoveVertical()
    {
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * ySpeed * Time.deltaTime;
        float yNewPosition = transform.localPosition.y + yOffset;
        float yClampedPosition = Mathf.Clamp(yNewPosition, -yMaximumMovement, yMaximumMovement);
        transform.localPosition = new Vector3(transform.localPosition.x, yClampedPosition, transform.localPosition.z);
    }

    private void ProcessRotation()
    {
        float pitch = (transform.localPosition.y * positionPitchFactor) + (yThrow * controlPitchFactor);
        float yawl = transform.localPosition.x * positionYawlFactor;
        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yawl, roll);
    }

    // Called by string reference
    void OnPlayerDeath()
    {
        isControlEnabled = false;
    }
}
