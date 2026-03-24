using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TorqueRotate : MonoBehaviour
{
    [Header("Rotation Settings")]
    public float torqueAmount = 50f;
    public float stoppingPower = 5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = 50f;
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddTorque(Vector3.forward * torqueAmount, ForceMode.Force);
        }
        else
        {
          
            rb.angularVelocity = Vector3.Lerp(rb.angularVelocity, Vector3.zero, Time.fixedDeltaTime * stoppingPower);
        }
    }
}