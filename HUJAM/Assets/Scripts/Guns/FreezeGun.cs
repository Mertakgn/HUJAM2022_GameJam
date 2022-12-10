using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeGun : Collectable
{
    [SerializeField] CapsuleCollider2D capsuleCollider;
    private float maxtimer;
    private float curtimer;
    private void Start()
    {
        maxtimer = 4f;
        curtimer = maxtimer;
    }

    void FixedUpdate()
    {

        if (curtimer >= 0)
        {
            capsuleCollider.enabled = false;
            curtimer -= Time.deltaTime;
        }
        else if(curtimer >= -0.5f)
        {
            curtimer -= Time.deltaTime;
            capsuleCollider.enabled = true;
        }
        else
        {
            curtimer = maxtimer;

        }
    }
}

