using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objpoolingmanager : MonoBehaviour
{
    //private static objpoolingmanager instance;
    public static objpoolingmanager Instance { get; private set; }


    public GameObject bulletprefab;
    public int bulletamount=20;
    private List<GameObject> bullets;
    void Awake()
    {
        Instance = this;
        bullets = new List<GameObject>(bulletamount);

        for(int i=0; i<bulletamount;i++)
        {
            GameObject prefabinstance = Instantiate(bulletprefab);
            prefabinstance.transform.SetParent(transform);
            prefabinstance.SetActive(false);

            bullets.Add(prefabinstance);
        }
    }

    public GameObject getbullet(bool shotbyplayer)
    {
       foreach(GameObject bullet in bullets)
        {
            if(!bullet.activeInHierarchy)
            {
                bullet.SetActive(true);
                bullet.GetComponent<bullet>().shotbyplayerpub = shotbyplayer;
                return bullet;
            }

        }
        GameObject prefabinstance = Instantiate(bulletprefab);
        prefabinstance.transform.SetParent(transform);
        
        prefabinstance.GetComponent<bullet>().shotbyplayerpub = shotbyplayer;
        bullets.Add(prefabinstance);
        return prefabinstance;
    }
}
