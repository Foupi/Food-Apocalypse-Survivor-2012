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


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // FIXME
        Shoot();
    }

    // Shoots food
    private void Shoot()
    {
        GameObject p = Instantiate(food, transform.position, Quaternion.identity);
        Vector3 direction = target.position - p.transform.position;
        p.GetComponent<Rigidbody2D>().velocity = direction.normalized * Speed;
    }
}
