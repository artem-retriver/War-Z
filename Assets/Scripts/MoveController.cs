using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private FixedJoystick joystick;

    [SerializeField] private float speed;
    public bool isRun;

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(joystick.Horizontal * speed, rb.velocity.y, joystick.Vertical * speed);

        if(joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            isRun = true;
            transform.rotation = Quaternion.LookRotation(rb.velocity);
        }
        else
        {
            isRun = false;
        }
    }

    public void UnMove()
    {
        rb.velocity = Vector3.zero;
    }
}
