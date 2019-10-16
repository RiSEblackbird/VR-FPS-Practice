using UnityEngine;

public class DebugMover : MonoBehaviour
{
    [SerializeField]
    Transform Head = null;
    const float Angle = 30f;
    const float DashSpeed = 5f;
    const float SlowSpeed = 0.2f;

    void Reset()
    {
        Head = GetComponentInChildren<OVRCameraRig>().transform.Find("TrackingSpace/CenterEyeAnchor");
    }

    float Scale
    {
        get
        {
            return IsPressTrigger ? DashSpeed : IsPressGrip ? SlowSpeed : 1f;
        }
    }

    bool IsPressTrigger
    {
        get
        {
            return Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)
            || OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger);
        }
    }
    bool IsPressGrip
    {
        get
        {
            return Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.LeftAlt)
            || OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) || OVRInput.Get(OVRInput.Button.SecondaryHandTrigger);
        }
    }

    void Update()
    {
        // Forward move
        if (Input.GetKey(KeyCode.W) || OVRInput.Get(OVRInput.Button.PrimaryThumbstickUp) || OVRInput.Get(OVRInput.Button.SecondaryThumbstickUp))
        {
            var forward = Head.forward;
            forward.y = 0;
            transform.position += forward.normalized * Time.deltaTime * Scale;
        }
        // Back move
        if (Input.GetKey(KeyCode.S) || OVRInput.Get(OVRInput.Button.PrimaryThumbstickDown) || OVRInput.Get(OVRInput.Button.SecondaryThumbstickDown))
        {
            var forward = Head.forward;
            forward.y = 0;
            transform.position -= forward.normalized * Time.deltaTime * Scale;
        }
        // Left rotate
        if (Input.GetKeyDown(KeyCode.A) || OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickLeft) || OVRInput.GetDown(OVRInput.Button.SecondaryThumbstickLeft))
        {
            transform.Rotate(0, -Angle, 0);
        }
        // Right rotate
        if (Input.GetKeyDown(KeyCode.D) || OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickRight) || OVRInput.GetDown(OVRInput.Button.SecondaryThumbstickRight))
        {
            transform.Rotate(0, Angle, 0);
        }
        // Up move
        if (Input.GetKeyDown(KeyCode.K) || OVRInput.GetDown(OVRInput.Button.Four) || OVRInput.GetDown(OVRInput.Button.Two))
        {
            transform.position += Vector3.up * Scale;
        }
        // Down move
        if (Input.GetKeyDown(KeyCode.J) || OVRInput.GetDown(OVRInput.Button.Three) || OVRInput.GetDown(OVRInput.Button.One))
        {
            transform.position -= Vector3.up * Scale;
        }
    }
}
