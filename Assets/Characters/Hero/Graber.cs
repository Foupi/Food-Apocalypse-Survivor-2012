using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graber : MonoBehaviour
{
    private Collider2D GrabRange;

    private Chair ChairToGrab = null;
    private Chair ChairGrabbed = null;
    private bool Pressing;

    // Start is called before the first frame update
    void Start()
    {
        GrabRange = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Grab") > 0 && !Pressing)
        {
            if (ChairGrabbed == null)
            {
                if (ChairToGrab != null)
                {
                    ChairToGrab.transform.parent = transform;
                    ChairGrabbed = ChairToGrab;
                }
            }
            else
            {
                ChairGrabbed.transform.parent = null;
                ChairGrabbed = null;
            }
        }

        Pressing = (Input.GetAxis("Grab") > 0);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (ChairToGrab != null)
            return;

        if(collision.TryGetComponent(out Chair chair))
        {
            ChairToGrab = chair;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Chair chair))
            if (chair == ChairToGrab)
                ChairToGrab = null;
    }

    public bool IsGrabbing()
    {
        return ChairGrabbed != null;
    }
}
