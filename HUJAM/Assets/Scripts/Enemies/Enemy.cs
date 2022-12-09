using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] internal EnemyValuesSO valuesSO;
    protected float health;
    protected float moveSpeed;
    protected float rotationSpeed;
    protected float damage;

    public static Transform Target;

    private void OnEnable()
    {
        Target = GameObject.FindWithTag("Player").transform;
    }

    protected void AssignValues()
    {
        health = valuesSO.health;
        moveSpeed = valuesSO.moveSpeed;
        rotationSpeed = valuesSO.rotationSpeed;
        damage = valuesSO.damage;
    }

    public abstract void Move();
    public abstract void EnemyDied();
}
