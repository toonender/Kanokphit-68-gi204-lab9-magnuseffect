using UnityEngine;

public class MagnusSoccerKick : MonoBehaviour
{
    public float kickForce = 18f;
    public float spinAmount = -20f;
    public float magnusStrength = 0.005f;

    private Rigidbody rb;
    private bool hasBeenKicked;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = 100f;

        Time.timeScale = 0.5f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !hasBeenKicked)
        {
            Kick();
        }
    }

    void FixedUpdate()
    {
        if (hasBeenKicked)
        {
            rb.AddForce(Vector3.Cross(rb.angularVelocity, rb.linearVelocity) * magnusStrength);
        }
    }

    void Kick()
    {
        hasBeenKicked = true;
        rb.AddForce((Vector3.left + (Vector3.up * 0.3f)) * kickForce, ForceMode.Impulse);
        rb.AddTorque(new Vector3(0f, spinAmount, 0f), ForceMode.Impulse);
    }
}