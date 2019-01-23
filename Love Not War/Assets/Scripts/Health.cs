using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image healthbar;
    public float max_health = 100f;
    public float cur_health = 0f;

    // Start is called before the first frame update
    void Start()
    {
        cur_health = max_health;
        SetHealthBar();
    }

    public void TakeDamage(float damage)
    {
        cur_health -= damage;
        SetHealthBar();
    }

    public void SetHealthBar()
    {
        float my_health = cur_health / max_health;
        healthbar.transform.localScale = new Vector3(Mathf.Clamp(my_health, 0f, 1f), healthbar.transform.localScale.y, healthbar.transform.localScale.z);
    }
}
