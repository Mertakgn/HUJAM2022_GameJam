using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : Collectable
{
    [SerializeField] protected GameObject prefabObj, ObjGO;
    [SerializeField] protected Transform SpawnPoint;


    // Update is called once per frame
    public void Update()
    {
        Spawn();



    }
    public virtual void Spawn()
    {
        if (ObjGO == null)
        {
            ObjGO = Instantiate(prefabObj, SpawnPoint.position, Quaternion.identity);
           

        }
    }

}
