using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header ("Health")]
    
    [SerializeField] private float  startindHealth;
    public float currentHealyh { get; private set; }
    private bool dead;

    [Header("iFrames")]
     [SerializeField]private float iFramesDuration;
    [SerializeField] private int  numberOfFlashes;
    private SpriteRenderer spriteRend;
    private Animator anim;
    




    private void Awake()
    {
        currentHealyh = startindHealth;
        spriteRend= GetComponent<SpriteRenderer>();
        anim= GetComponent<Animator>();
    }
    public void TakeDamage(float Damage)
    {
        currentHealyh = Mathf.Clamp(currentHealyh - Damage, 0, startindHealth);
        if(currentHealyh > 0)
        {
            StartCoroutine(Invunerability());
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("DIE");
                GetComponent<Jump>().enabled = false;
                GetComponent<Move>().enabled = false;
                dead = true;
                 

            }
           
        } 
    }
    public void AddHealth(float Value)
    {
        currentHealyh = Mathf.Clamp(currentHealyh + Value, 0, startindHealth);
    }
    private IEnumerator Invunerability()
    {

        Physics2D.IgnoreLayerCollision(6,7,true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration/ (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(6, 7, false);
    }
   

}
