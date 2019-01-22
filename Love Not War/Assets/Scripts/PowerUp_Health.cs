using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Health : MonoBehaviour, Powerups
{
    public int amount; //Hp increase amount
    public string playerTagName; //Player tag (Generic)
    
    //Interface implementation--------------------//
    public void effect()
    {
        //TEMP_PLAYER.hp += amount;
        GetComponent<Player>().hp += amount;
    }

    public void expire()
    {
        return; //Doesn't expire
    }
    //-------------------------------------------//

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == playerTagName)
        {
            //Do effect on Player entering trigger collider, then destroy object
            this.effect();
            Destroy(this.gameObject);
        }
    }

}
