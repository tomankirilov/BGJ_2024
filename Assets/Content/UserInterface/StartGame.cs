using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // [SerializeField] Animation anim;
    void Start()
    {
        // anim.Play("Intro");
    }

    public void OnStartGame(){
        
        SceneManager.LoadScene("Level_01");
    }
}
