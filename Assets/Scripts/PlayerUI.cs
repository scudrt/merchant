﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Company company;

    private GameObject playerInfoPanel;
    private GameObject bottomPanel;
    private GameObject talentsManagePanel;

    /******get all data text on bottom panel*******/
    private Text property;
    private Text reputation;
    private Text GDP;
    private Text population;
    private Text trend;

    // Start is called before the first frame update
    void Start()
    {
        company = City.currentCompany;

        playerInfoPanel = transform.Find("PlayerInfoPanel").gameObject;
        bottomPanel = transform.Find("BottomPanel").gameObject;
        talentsManagePanel = transform.Find("TalentsManagePanel").gameObject;

        property = bottomPanel.transform.Find("Property").GetComponent<Text>();
        reputation = bottomPanel.transform.Find("Reputation").GetComponent<Text>();
        GDP = bottomPanel.transform.Find("GDP").GetComponent<Text>();
        population = bottomPanel.transform.Find("Population").GetComponent<Text>();
        trend = bottomPanel.transform.Find("Trend").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //property.text = City.currentCompany.fund.ToString();
        //reputation.text = City.currentCompany.fame.ToString();
        //population.text = Population.totalAmount.ToString();
    }

    public void PlayerInfoPanelEntry()
    {
        playerInfoPanel.SetActive(true);
    }

    public void PlayerInfoPanelExit()
    {
        playerInfoPanel.SetActive(false);
    }

    public void TalentsManagePanelEntry()
    {
        /*****test code******/
        Talent talent = new Talent();
        talent.name = "drt";
        City.currentCompany.talentList.Add(talent);
        /*****test code******/
        talentsManagePanel.GetComponent<FullScreenPanel>().UIEntry();
        talentsManagePanel.GetComponent<TalentManageUI>().OnOpen();
    }

    public void TalentsManagePanelExit()
    {
        talentsManagePanel.SetActive(false);
    }
}
