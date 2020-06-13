using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMovement : Character
{
    public float GrabSpeed;

    public Sprite DeadSprite;

    private float normalSpeed;
    private Graber graber;
    private bool deactivate = false;

    public void Deactivate()
    {
        deactivate = true;
        RB.velocity = Vector3.zero;
    }

    public void Kill()
    {
        StartCoroutine(KillCoroutine());
    }

    IEnumerator KillCoroutine()
    {
        Deactivate();
        GetComponent<SpriteRenderer>().sprite = DeadSprite;

        yield return new WaitForSeconds(1);

        GameManager.Instance.ResetScene();
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        graber = GetComponentInChildren<Graber>();
        normalSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (deactivate)
            return;

        speed = (graber.IsGrabbing()) ? GrabSpeed : normalSpeed;

        Move(GetDirection());
    }

    private Vector3 GetDirection()
    {
        return new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
}
