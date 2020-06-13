using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    public GameObject BlackScreen;
    public MaskTransition Transition;

    private HeroMovement Hero;
    //Currently changing scene
    private bool transitionning = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Hero = FindObjectOfType<HeroMovement>();
    }

    public void ResetScene()
    {
        ChangeScene(SceneManager.GetActiveScene().name);
    }

    public void ChangeScene(string scene)
    {
        if (transitionning)
            return;
        transitionning = true;
        Instantiate(BlackScreen);
        Vector3 pos = Camera.main.transform.position;
        Instantiate(Transition, new Vector3(pos.x, pos.y), Quaternion.identity).Init(scene);
        Hero.Deactivate();
    }
}
