using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MaskTransition : MonoBehaviour
{
    public float MinSize;
    public float TimeTransition;

    private float MaxSize;
    private string scene = "Winning";
    private float timer;
    public void Init(string sceneTarget)
    {
        scene = sceneTarget;
    }

    public void Start()
    {
        MaxSize = transform.localScale.x;
        timer = TimeTransition;
    }

    private void FixedUpdate()
    {
        timer -= Time.deltaTime;

        float size = (MaxSize - MinSize) * (timer / TimeTransition) + MinSize;

        transform.localScale = new Vector3(size, size, 1);

        if (timer <= 0)
            EndTransition();
    }

    void EndTransition()
    {
        SceneManager.LoadScene(scene);
    }
}
