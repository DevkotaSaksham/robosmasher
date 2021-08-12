using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    [Header("VISUALS")]
    public Camera playercamera;
    [Header("Gameplay")]
    public int initialammo = 9;
    private int ammo;
    public int Ammo { get { return ammo; } }

    public int initialhealth = 100;

    private int health;
    public int Health { get { return health; } }

    private bool killed;   public bool Killed { get { return killed; } }

    public int knockforce = 60;
    private bool ishurt;
    public float hurtduration = 0.5f;

    void Start()
    {
        ammo = initialammo;
        health = initialhealth;
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (ammo > 0 && killed==false)
            {
                ammo--;
                GameObject bulletobject = objpoolingmanager.Instance.getbullet(true);
                bulletobject.transform.position = playercamera.transform.position + playercamera.transform.forward;
                bulletobject.transform.forward = playercamera.transform.forward;

            }
            
        }

    }
    void OnTriggerEnter(Collider hit)
    {
        if (hit.GetComponent<ammocrate>() != null)
        {

            ammocrate ammocrate = hit.GetComponent<ammocrate>();
            ammo += ammocrate.AmmoAddUp;

            Destroy(ammocrate.gameObject);
        }
        if (ishurt == false)
        {
           
            if (hit.GetComponent<enemy>() != null)
            {
               
                enemy enemy = hit.GetComponent<enemy>();

                health -= enemy.damagetoother;
                ishurt = true;
                if (health <= 0) { onkilled(); }
                Vector3 hurtdirection = (this.transform.position - enemy.transform.position).normalized;
                Vector3 knockdirection = (hurtdirection + Vector3.up).normalized;
                GetComponent<forcereceiver>().addforce(knockdirection, knockforce);
                StartCoroutine(hurtroutine());

            }
             else if (hit.GetComponent<bullet>() != null)
            {
                 bullet bullet = hit.GetComponent<bullet>();
                 if (bullet.shotbyplayerpub == false)
                 {
                     health -= bullet.bulletdamage;
                     ishurt = true;
                    if (health <= 0) { onkilled(); }
                    StartCoroutine(hurtroutine());
                    bullet.gameObject.SetActive(false);
                }


            }
           
        }







    }



    IEnumerator hurtroutine()
    {
        yield return new WaitForSeconds(hurtduration);
        ishurt = false;


    }

    private void onkilled()
    {
        killed = true;
        GetComponent<CharacterController>().enabled = false;


    }


}
    










