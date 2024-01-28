using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] Animator anim;
    void Start()
    {
        
    }

    public void OnStartGame(){
        
        anim.Play("Outro");
    }

    public void OnOutroEnd()
    {
        SceneManager.LoadScene("Level_01");
        // Debug.Log("");
    }
}
