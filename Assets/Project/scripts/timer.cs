using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timer : MonoBehaviour
{
    private float mytime = 2.2f;

    // Update is called once per frame
    void Update()
    {
        mytime -= Time.deltaTime;
        if (mytime <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
