using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemy : Enemy
{
    private void Start()
    {
        AssignValues();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public override void Move()
    {
        transform.right = Target.position - transform.position;

        transform.position = Vector3.MoveTowards(transform.position, Target.position, moveSpeed);
    }

    public override void EnemyDied()
    {
        //throw new System.NotImplementedException();
    }
}