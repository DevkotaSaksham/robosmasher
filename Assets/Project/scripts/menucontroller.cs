using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menucontroller : MonoBehaviour

{

    public AudioSource bgmusic;
    public void Onplay()
    {
        SceneManager.LoadScene("level1");


    }
    private void Start()
    {
        bgmusic.Play();
    }
}
