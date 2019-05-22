﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public void OnExitButtonClick()
    {
        //Remember to call agent to save data before
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void OnSingleStartButtonClick()
    {
        GetComponentInParent<Canvas>().enabled = false; //disable main menu
        Agent.enableAllRoomScripts(); //enable the room scripts
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
