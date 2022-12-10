using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICanDealDamage 
{

    public float Damage { get; set; }

    public void DealDamage(float damage,Enemy enemy);
}
