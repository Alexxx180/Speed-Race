using System;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float runSpeed = 1f;
    float horizontalMove = 0f;

    public List<GameObject> roads;
    public int selected = 1;

    public Rigidbody2D body;
    private Vector3 _Velocity = Vector3.zero;

    // Start is called before the first frame update
    void Update()
    {
        float axis = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("ChangeRoad"))
            ChangeRoad(Convert.ToInt32(axis));
        //horizontalMove = Input.GetButton("ChangeRoad") ? axis * runSpeed : 0;
    }

    void ChangeRoad(int increment)
    {
        selected = Mathf.Clamp(selected + increment, 0, 2);
        gameObject.transform.position = roads[selected].transform.position;
    }

    void SmoothMovement()
    {
        Vector3 targetVelocity = new Vector2(horizontalMove * 10f, body.velocity.y);
        body.velocity = Vector3.SmoothDamp(body.velocity, targetVelocity, ref _Velocity, 0.05f);
    }

    private void FixedUpdate()
    {
        //SmoothMovement()
    }
}
