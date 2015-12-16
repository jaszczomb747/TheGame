using UnityEngine;

public class Cube_Move : MonoBehaviour
{
    public float speed = 20f;
    public float rotation_speed = 70f;
    private Rigidbody r;

    private void Start()
    {
        r = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float forward = Input.GetAxis("Vertical");
        float right = Input.GetAxis("Horizontal");

        Vector3 eulerAngleVelocity = new Vector3(0.0f, right, 0.0f);

        r.MovePosition(transform.position + transform.forward * forward * Time.deltaTime * speed);
        Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime * rotation_speed);

     
        r.MoveRotation(r.rotation * deltaRotation);
    }
}