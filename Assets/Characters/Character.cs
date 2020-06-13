using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float speed;
    protected Rigidbody2D RB;

    protected virtual void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }
    protected void Move(Vector3 Direction)
    {
        if (Direction.sqrMagnitude > 1)
            Direction = Direction.normalized;

        RB.velocity = Direction * speed;
    }
}
