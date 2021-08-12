using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gamecontroller : MonoBehaviour
{
    [Header("game")]
    public player player;
    public GameObject enemygang;
 
    [Header("UI")]
    public Text ammotext;
    public Text healthtext;
    public Text winningtext;
    public AudioSource backgroundmusic;

    private float resettimer = 3.3f;
    private bool gameover;
    private void Start()
    {
        winningtext.gameObject.SetActive(false);
        backgroundmusic.Play();
    }
    void Update()
    {
        ammotext.text = " Ammo: "+player.Ammo;
        healthtext.text = " HEALTH: " + player.Health;
        if (enemygang.GetComponentsInChildren<shootingenemy>().Length == 0) 
        {
            winningtext.gameObject.SetActive(true);
            winningtext.text = "We did it Mr. Stark!";
            gameover = true;

        }
        if (player.Killed == true)        
        {
            winningtext.gameObject.SetActive(true);
            winningtext.text = "GAME OVER Biyaaaach!";
            gameover = true;
            healthtext.gameObject.SetActive(false);
        }

        if (gameover == true)
        {
            resettimer -= Time.deltaTime;
            if (resettimer <= 0)
            {
                SceneManager.LoadScene("menu");
            }
        }
    }
}
