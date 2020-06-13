using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Donut : Collectible
{
    private ExitDoor ExitDoor;
    private void Start()
    {
        ExitDoor = FindObjectOfType<ExitDoor>();
    }
    protected override void OnCollectEffect(HeroMovement Hero)
    {
        ExitDoor.Activate();
    }
}
