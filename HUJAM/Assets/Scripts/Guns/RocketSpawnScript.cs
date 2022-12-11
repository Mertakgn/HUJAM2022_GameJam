using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSpawnScript : ItemSpawner
{
    float curtimer, maxtimer;
    [SerializeField] ParticleSystem rocketLaunchParticle;
    [SerializeField] Transform playerTransform;


    void Start()
    {
        playerTransform = GameObject.FindObjectOfType<PlayerMovement>().transform;
        maxtimer = 1f;
        curtimer = maxtimer;
    }



    public override void Spawn()
    {
        if (ObjGO == null)
        {
            curtimer -= Time.deltaTime;
            if (curtimer <= 0)
            {
                ObjGO = Instantiate(prefabObj, SpawnPoint.position, Quaternion.identity);


                rocketLaunchParticle.Play();
                curtimer = maxtimer;

            }
           



        }
    }
}
