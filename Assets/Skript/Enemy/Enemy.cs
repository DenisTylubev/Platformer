using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public void TakaDamage(int damage)
    {
        health -= damage;
 
    }
    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject); 
        }
    }
}
