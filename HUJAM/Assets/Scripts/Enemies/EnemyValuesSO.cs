using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySO", menuName = "Scriptable Objects/Enemy Values")]
public class EnemyValuesSO : ScriptableObject
{
    public float health;
    public float moveSpeed;
    public float rotationSpeed;
    public float damage;
    public bool isRanged;
}
