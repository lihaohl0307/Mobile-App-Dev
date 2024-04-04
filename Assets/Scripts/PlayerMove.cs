using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    private Rigidbody rb;
    protected Joystick joystick;
    public float speed = 10f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        joystick = FindObjectOfType<Joystick>(joystick );
    }

    void Update()
    {
        rb.velocity = new Vector2(joystick.Horizontal * speed, joystick.Vertical * 0);
    }
}
