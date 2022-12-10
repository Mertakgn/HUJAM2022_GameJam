using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

public class RocketString : MonoBehaviour , ICanDealDamage
{
   [SerializeField] float dirRandomizer;
    

     float curtimer, maxtimer;

    [SerializeField] float moveSpeed;

    [SerializeField] float damage;
    public float Damage { get => damage; set => damage = value; }

    private void Start()
    {
        maxtimer = 1f;
        curtimer = maxtimer;
        dirRandomizer = Random.Range(-180, 180);
        
        Destroy(gameObject, 2f);
    }


    private void FixedUpdate()
    {
        RandomMovement();
    }

    void RandomMovement()
    {
        
        if(curtimer >=0)
        {
            curtimer -= Time.deltaTime;
            Quaternion tempTarget = Quaternion.Euler(transform.rotation.x, transform.rotation.y, Mathf.Lerp(transform.rotation.z, dirRandomizer, 1f));
            transform.rotation = Quaternion.Lerp(transform.rotation,tempTarget,Time.deltaTime*1f);
            transform.Translate(new Vector3(transform.rotation.z,50f, 0f) * Time.deltaTime*moveSpeed);
        }
        else
        {
            dirRandomizer = Random.Range(-180,180);
            curtimer = maxtimer;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>() != null)
        {
            DealDamage(Damage, collision.GetComponent<Enemy>());
        }
    }

    public void DealDamage(float damage, Enemy enemy)
    {
        enemy.TakeDamage(damage);

    }
}
