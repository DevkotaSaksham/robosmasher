using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    public float speed=12f;
    public float lifeduration=2f;
    private float lifetimer;
    public int bulletdamage = 5;

    private bool shotbyplayer;
    public bool shotbyplayerpub { get { return shotbyplayer; } set { shotbyplayer= value; } }
    
    private void OnEnable()
    {
        lifetimer = lifeduration;
    }
   
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;

        lifetimer -= Time.deltaTime;
        if (lifetimer <= 0f)
        {
            gameObject.SetActive(false);
        }
    }
}
