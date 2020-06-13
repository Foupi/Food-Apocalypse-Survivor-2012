using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : Collectible
{
    [SerializeField]
    private string SceneName;
    [SerializeField]
    private Sprite ActivatedSprite;

    private bool activated = false;
    public void Activate()
    {
        activated = true;
        GetComponent<SpriteRenderer>().sprite = ActivatedSprite;
        GetComponent<Collider2D>().isTrigger = true;
    }

    protected override void OnCollectEffect(HeroMovement Hero)
    {
        if (activated)
            GameManager.Instance.ChangeScene(SceneName);
    }
}
