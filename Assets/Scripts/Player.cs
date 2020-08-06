using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{

    [Tooltip("In meters per second")][SerializeField] float xSpeed = 8f;
    [Tooltip("In meters per second")] [SerializeField] float ySpeed = 8f;
    [Tooltip("In meters")] [SerializeField] float xMaximumMovement = 6f;
    [Tooltip("In meters")] [SerializeField] float yMaximumMovement = 4f;
    [SerializeField] float positionPitchFactor = -3f;
    [SerializeField] float controlPitchFactor = -15f;
    [SerializeField] float positionYawlFactor = 3f;
    [SerializeField] float controlRollFactor = -20f;

    float xThrow;
    float yThrow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveHorizontal();
        MoveVertical();
        ProcessRotation();
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
}
