﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingButton : MonoBehaviour
{

    public Canvas buildingUI;//reference to BuildingUI so that all buttons can access to it

    public Object prefab;//building's prefab

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnExitButtonClick()
    {
        SendMessageUpwards("UIExit");
    }

    public void OnBuyButtonClick()
    {
        buildingUI.GetComponent<BuildingUI>().Building.GetComponent<Building>().status 
            = Building.Status.BOUGHT; //change building's status to BOUGHT

        SendMessageUpwards("UIExit");
        SendMessageUpwards("BoughtPanelEntry");
    }

    public void OnBuildButtonClick()
    {
        GameObject building = buildingUI.GetComponent<BuildingUI>().Building; //the building controlled

        building.GetComponent<Building>().status= Building.Status.BUILT; //change building's status to BUILT

        GameObject newBuilding = (GameObject) GameObject.Instantiate(prefab, building.transform);

        SendMessageUpwards("UIExit");
        SendMessageUpwards("BuildingPanelEntry");
    }
}