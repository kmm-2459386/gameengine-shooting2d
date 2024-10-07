using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public VirtualJoystick joystick;

    void Update()
    {
        float horizontal = joystick.Horizontal();
        float vertical = joystick.Vertical();

        Vector3 movement = new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime;
        transform.Translate(movement);
    }
}