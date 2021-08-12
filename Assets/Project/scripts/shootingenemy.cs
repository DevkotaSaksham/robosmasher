using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class shootingenemy : enemy
{
   

    private player player;
    private float shootingtimer;

  //  public AudioSource deathsound;

    public float shootinginterval = 3f;
    public float shootdistance = 10f;

    public float chasinginterval = 2f;
    public float chasingdistance = 45f;
    private float chasingtimer;

    private NavMeshAgent agent;
    public ParticleSystem deatheffect;

    //public int damagebytouching = 90;
   // public int shootenemyhealth = 50;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("player").GetComponent<player>();
        shootingtimer = Random.Range(0, shootinginterval);
        agent.SetDestination(player.transform.position);
    }

   
    void Update()
    {
        if (player.Killed == true)
        {
            agent.enabled = false;
            this.enabled = false;
        }

        shootingtimer -= Time.deltaTime;
        if (shootingtimer <= 0 && Vector3.Distance(transform.position,player.transform.position)<=shootdistance)
        {
            shootingtimer = shootinginterval;

            GameObject bullet = objpoolingmanager.Instance.getbullet(false);

            bullet.transform.position = this.transform.position; //transform.position;
            bullet.transform.forward = (player.transform.position - this.transform.position).normalized;

        }
        chasingtimer -= Time.deltaTime;
        if (chasingtimer <= 0 && Vector3.Distance(transform.position, player.transform.position) <= chasingdistance)
        {
            chasingtimer = chasinginterval;
            agent.SetDestination(player.transform.position);
        }
        
    }

    protected override void onkill()
    {
        base.onkill();
       
        
       
        agent.enabled = false;
        //this.enabled = false;
       
        Instantiate(deatheffect, this.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
