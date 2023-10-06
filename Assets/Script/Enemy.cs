using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType
{
    Bandit,
    Wolf,
    Slime,
}
[CreateAssetMenu(fileName = "New Enemy", menuName = "Add Enemy")]
public class Enemy : ScriptableObject
{
    public ItemType type;
    public GameObject enemyPrefab;
    //public float health; //надо подумать надо ли это
}
