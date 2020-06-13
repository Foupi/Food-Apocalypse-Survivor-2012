﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMovement : MonoBehaviour
{
    private Rigidbody2D RB;
    public float speed;

    private bool deactivate = false;

    public void Deactivate()
    {
        deactivate = true;
        RB.velocity = Vector3.zero;
    }

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (deactivate)
            return;

        Move(GetDirection());
    }

    private Vector3 GetDirection()
    {
        return new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void Move(Vector3 Direction)
    {
        if (Direction.sqrMagnitude > 1)
            Direction = Direction.normalized;
        RB.velocity = Direction * speed;
    }
}
