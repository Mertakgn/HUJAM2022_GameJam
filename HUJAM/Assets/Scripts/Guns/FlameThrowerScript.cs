using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrowerScript : Collectable
{
    [SerializeField] Collider2D flameCollider;

    [SerializeField] GameObject FlameVfx;
    void Start()
    {
        flameCollider.enabled = true;
        FlameVfx.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
