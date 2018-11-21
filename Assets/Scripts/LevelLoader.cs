using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

    [SerializeField] float splashDelay = 1f;

    // Use this for initialization
    void Start () 
    {
        Invoke("GoToFirstLevel", splashDelay);
	}
    void GoToFirstLevel ()
    {
        SceneManager.LoadScene(1);
    }
 	
	}

