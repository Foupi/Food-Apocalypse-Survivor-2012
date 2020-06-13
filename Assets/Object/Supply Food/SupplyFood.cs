using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupplyFood : MonoBehaviour
{
    public Sprite[] Sprites;
    public SpriteRenderer SpriteRenderer { get; private set; }

    // Start is called before the first frame update
    void Awake()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        SpriteRenderer.sprite = Sprites[Random.Range(0, Sprites.Length)];
    }

    public void PutOnPlate(Vector3 PlatePos, SupplyTable table)
    {
        transform.position = PlatePos;
        transform.parent = table.transform;
        SpriteRenderer.enabled = true;
        SpriteRenderer.sortingOrder = (int) -transform.position.y * 100;

    }

    public void Grab(Transform transform)
    {
        this.transform.parent = transform;
        SpriteRenderer.enabled = false;
    }

    public void Consume()
    {
        Destroy(gameObject);
    }
}
