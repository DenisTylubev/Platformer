using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealyhCollectuble : MonoBehaviour
{
    
    [SerializeField]private float HealthVAlue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().AddHealth(HealthVAlue);
            gameObject.SetActive(false);

        }
    }
}
