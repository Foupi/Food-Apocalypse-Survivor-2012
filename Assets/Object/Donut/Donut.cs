using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Donut : Collectible
{
    public string SceneName;
    protected override void OnCollectEffect(HeroMovement Hero)
    {
        SceneManager.LoadScene(SceneName);
    }
}
