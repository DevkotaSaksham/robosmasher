using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    public int enemyhealth = 6;
    public int damagetoother = 10;
    public int damageitself = 3;

    void OnTriggerEnter(Collider othercollider)
    {
        if (othercollider.GetComponent<bullet>() != null)
        {
            bullet bullet = othercollider.GetComponent<bullet>();
            if (bullet.shotbyplayerpub == true)
            {
                enemyhealth -= damageitself;
               
                bullet.gameObject.SetActive(false);

                if (enemyhealth <= 0)
                {
                    onkill();
                  
                }
            }


        }
       
    }

    protected virtual void onkill() {  }


}
