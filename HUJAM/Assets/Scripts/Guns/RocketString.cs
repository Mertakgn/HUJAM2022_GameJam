using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

public class RocketString : MonoBehaviour , ICanDealDamage
{
   [SerializeField] float dirRandomizer;
    

     float curtimer, maxtimer, midTimer;

    [SerializeField] float moveSpeed;

    [SerializeField] float damage;
    public float Damage { get => damage; set => damage = value; }

    [SerializeField] Transform playerTransform;


    float playerup;

    private void Start()
    {
        maxtimer = 1.3f;
        midTimer = 0.7f;
        curtimer = maxtimer;
        dirRandomizer = Random.Range(-180, 180);
        playerTransform = GameObject.FindObjectOfType<PlayerMovement>().transform;
        playerup = playerTransform.eulerAngles.z;
        Destroy(gameObject, 2f);
    }


    private void FixedUpdate()
    {
        RandomMovement();
    }

    void RandomMovement()
    {
        if(curtimer >=1)
        {
            Debug.Log("Player  " + playerup + "  Local Rot: " + transform.rotation.z);
            curtimer -= Time.deltaTime;
            //Quaternion tempTarget = Quaternion.Euler(transform.rotation.x, transform.rotation.y, dirRandomizer );
            Quaternion tempTarget = Quaternion.Euler(transform.rotation.x, transform.rotation.y, playerup);
            transform.rotation = Quaternion.Lerp(transform.rotation,tempTarget ,Time.deltaTime * 5f);
            transform.Translate( transform.up * Time.deltaTime*moveSpeed);
        }
        else if (curtimer >= 0.5f)
        {
            Debug.Log("Player  " + playerup + "  Local Rot: " + transform.rotation.z);
            curtimer -= Time.deltaTime;
            Quaternion tempTarget = Quaternion.Euler(transform.rotation.x, transform.rotation.y, dirRandomizer);
            transform.rotation = Quaternion.Lerp(transform.rotation, tempTarget, Time.deltaTime * 5f);
            transform.Translate(transform.up * Time.deltaTime * moveSpeed);
        }
        else
        {
            dirRandomizer = Random.Range(-180,180);
            curtimer = midTimer;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>() != null)
        {
            DealDamage(Damage, collision.GetComponent<Enemy>());
            
            Destroy(gameObject);
        }
    }

    public void DealDamage(float damage, Enemy enemy)
    {
        enemy.TakeDamage(damage);
       


    }
}
