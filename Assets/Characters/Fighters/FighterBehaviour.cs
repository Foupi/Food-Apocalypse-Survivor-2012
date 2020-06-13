using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterBehaviour : MonoBehaviour
{
    // Aiming coordinates
    public Transform target;

    // Projectile
    public GameObject food;

    // Speed
    public float Speed;

    // Time between two shots
    public float CoolDown;

    // Time remaining before the next shot
    private float remainingCoolDown;

    // Collider of the fighter
    private Collider2D fighterCollider;

    // Start is called before the first frame update
    void Start()
    {
        remainingCoolDown = 0.0f;
        fighterCollider = this.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (remainingCoolDown <= 0.0f)
            Shoot();
        else
            remainingCoolDown -= Time.fixedDeltaTime;
    }

    // Shoots food and resets the cooldown
    private void Shoot()
    {
        ThrowFood();
        remainingCoolDown = CoolDown;
    }
    
    // Instanciates the food to be thrown, and throws it.
    private void ThrowFood()
    {
        GameObject p = Instantiate(food, transform.position, Quaternion.identity);
        Collider2D projectileCollider = p.GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(projectileCollider, fighterCollider);
        Vector3 direction = target.position - p.transform.position;
        p.GetComponent<Rigidbody2D>().velocity = direction.normalized * Speed;
    }
}
