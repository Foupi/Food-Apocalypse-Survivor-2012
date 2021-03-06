﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodImpact : MonoBehaviour
{
    // Max duration a food projectile can reach before disappearing
    public float Range;
    public Sprite[] Sprites;

    // Point from which the food projectile was thrown
    private Vector3 startPosition;

    // Start is called before the first frame update
    public void Init(SupplyFood Supply)
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        if (Supply != null)
            renderer.sprite = Supply.SpriteRenderer.sprite;
        else
            renderer.sprite = Sprites[Random.Range(0, Sprites.Length)];
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = transform.position;
        Vector3 currentDistanceVector = currentPosition - startPosition;
        float currentDistance = currentDistanceVector.magnitude;
        if (currentDistance >= Range)
            disappear();
    }

    // Reacts to contact with something
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out HeroMovement hero))
        {
            hero.Kill();
        }
        if (other.TryGetComponent(out FighterBehaviour fighter))
        {
            Debug.Log("Attack fighter !");
        }
        disappear();
    }

    // Time to die, little piece of whatever food you are... 
    private void disappear()
    {
        Destroy(gameObject);
    }
}
