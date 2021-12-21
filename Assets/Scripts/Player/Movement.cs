using System.Collections.Generic;
using static System.Convert;
using UnityEngine;
using static UnityEngine.Input;

public class Movement : MonoBehaviour
{
    public float runSpeed = 1f;

    public List<Transform> roads;
    public int selected = 1;

    public Rigidbody2D body;

    // Update is called once per frame
    void Update()
    {
        float axis = GetAxisRaw("Horizontal");
        MoveToRoad(ToInt32(axis));
    }

    // Here we check if negative "A" or positive "D" pressed
    private void MoveToRoad(int axis)
    {
        if (GetButtonDown("ChangeRoad"))
            ChangeRoad(axis);
    }

    void ChangeRoad(int increment)
    {
        selected = Mathf.Clamp(selected + increment, 0, 2);
        transform.position = roads[selected].position;
    }
}
