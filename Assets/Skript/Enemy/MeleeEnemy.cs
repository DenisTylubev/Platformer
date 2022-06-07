using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    [SerializeField] private float AttackColldown;
    [SerializeField] private float Range;
    [SerializeField] private float ColliderDistance;
    [SerializeField] private int Damage;
    [SerializeField] private BoxCollider2D BoxCollider;
    [SerializeField] private LayerMask Playerlayer;
    private float ColldownTimer = Mathf.Infinity;
    private Health PlayerHealyh;
    private void Update()
    {
        ColldownTimer += Time.deltaTime;
        if (PlayerInSight())
        {
            if (ColldownTimer >= AttackColldown)
            {
                ColldownTimer = 0;

            }
        }

    }
    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(BoxCollider.bounds.center + transform.right * Range * transform.localScale.x * ColliderDistance, new Vector3(BoxCollider.bounds.size.x * Range, BoxCollider.bounds.size.y,
            BoxCollider.bounds.size.z), 0, Vector2.left, 0, Playerlayer);
        if (hit.collider == null)
            PlayerHealyh = hit.transform.GetComponent<Health>();

        return hit.collider != null;
            
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(BoxCollider.bounds.center + transform.right * Range * transform.localScale.x * ColliderDistance, new Vector3(BoxCollider.bounds.size.x * Range, BoxCollider.bounds.size.y, BoxCollider.bounds.size.z));
    }
    private void DamagePlayer()
    {

        if (PlayerInSight())
            PlayerHealyh.TakeDamage(Damage);

    }
}

