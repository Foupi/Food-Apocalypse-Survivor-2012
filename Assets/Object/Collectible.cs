using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public bool destroyOnCollect = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out HeroMovement Hero))
        {
            OnCollectEffect(Hero);
            if (destroyOnCollect)
                Destroy(gameObject);
        }
    }

    protected virtual void OnCollectEffect(HeroMovement Hero) { }
}
