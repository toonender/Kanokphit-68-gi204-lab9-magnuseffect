using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AngularVelocity : MonoBehaviour
{
    [Header("Rotation Settings")]
    public float spinSpeed = 10f;

  
    public float decelerationRate = 5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = 50f;
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
         
            rb.angularVelocity = new Vector3(0, spinSpeed, 0);
        }
        else
        {
            rb.angularVelocity = Vector3.Lerp(rb.angularVelocity, Vector3.zero, Time.fixedDeltaTime * decelerationRate);
        }
    }
}