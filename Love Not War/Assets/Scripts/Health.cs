using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image healthbar;
    public float max_health = 100f;
    public float cur_health = 0f;
    public bool alive = true;
   private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        alive = true;
        cur_health = max_health;
        SetHealthBar();
        anim = GetComponentInChildren<Animator>();
    }

    public void FixedUpdate()
    {
        anim.SetBool("Alive", alive);
    }
    public void TakeDamage(float damage)
    {
        if(!alive)
        {
            return;
        }
        if(cur_health<=0)
        {
            cur_health = 0;
            alive = false;
        }
        cur_health -= damage;
        SetHealthBar();
    }

    public void SetHealthBar()
    {
        float my_health = cur_health / max_health;
        healthbar.transform.localScale = new Vector3(Mathf.Clamp(my_health, 0f, 1f), healthbar.transform.localScale.y, healthbar.transform.localScale.z);
    }
}
