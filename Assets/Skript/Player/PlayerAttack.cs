using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
   [SerializeField] private float TimeBtwAttack;
    private float CollDownAttack;
    public Transform AttackPos;
    public float AttackRange;
    public LayerMask WhatIsEnemy;
    public int Damage;

    private void Update()
    {
        if (TimeBtwAttack <= 0)
        {
            if(Input.GetKeyDown(KeyCode.T))
            {
                Collider2D[] EnemisToDamage = Physics2D.OverlapCircleAll(AttackPos.position,AttackRange,WhatIsEnemy);
                for (int i = 0; i < EnemisToDamage.Length; i++)
                {
                    EnemisToDamage[i].GetComponent<Enemy>().TakaDamage(Damage); 
                }
            }
            TimeBtwAttack = CollDownAttack;
        }
        else
        {
            TimeBtwAttack -= Time.deltaTime;
        }
    }
     void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(AttackPos.position, AttackRange);
    }

}
