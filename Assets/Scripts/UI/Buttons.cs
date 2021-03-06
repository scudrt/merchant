﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        SceneManager.LoadScene("GameScene");
    }

    public void OnAboutButtonClick(GameObject aboutPanel)
    {
        aboutPanel.SetActive(true);
    }

    public void OnPanelExitButtonClick(GameObject panel)
    {
        panel.SetActive(false);
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
