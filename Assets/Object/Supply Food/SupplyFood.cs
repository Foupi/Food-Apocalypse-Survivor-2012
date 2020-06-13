using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupplyFood : MonoBehaviour
{
    private SpriteRenderer SpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Grab(Transform transform)
    {
        this.transform.parent = transform;
        SpriteRenderer.enabled = false;
    }
}
