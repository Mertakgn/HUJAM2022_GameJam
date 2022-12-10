using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMove : MonoBehaviour,ICanDealDamage
{
    [SerializeField] float damage;

    public float Damage { get => damage; set => damage= value; }

    
    void Start()
    {

        Destroy(gameObject,4f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += transform.up * Time.deltaTime * 20;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>() != null)
        {
            collision.GetComponent<Enemy>().TakeDamage(damage);
        }
    }

    public void DealDamage(float damage, Enemy enemy)
    {
        throw new System.NotImplementedException();
    }
}
