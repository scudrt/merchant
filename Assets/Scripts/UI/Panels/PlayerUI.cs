﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public static int isInUI = 7;

    public Company company;

    private GameObject playerInfoPanel;
    private GameObject bottomPanel;
    private GameObject talentsManagePanel;
    private GameObject blocksManagePanel;
    private GameObject talentsMarketPanel;
    private GameObject companiesPanel;
    private GameObject contractSendPanel;
    private GameObject newsPanel;

    /******get all data text on bottom panel*******/
    private Text property;
    private Text reputation;
    private Text GDP;
    private Text population;
    private Text trend;

    public static void addUI()
    {
        isInUI++;
        if (isInUI > 0){
            GameObject.FindObjectOfType<Camera>().movable = false;
        }
    }

    public static void delUI()
    {
        isInUI--;
        if (isInUI == 0) {
            GameObject.FindObjectOfType<Camera>().movable = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        company = City.currentCompany;

        bottomPanel = transform.Find("BottomPanel").gameObject;
        talentsManagePanel = transform.Find("TalentsManagePanel").gameObject;
        blocksManagePanel = transform.Find("BlocksManagePanel").gameObject;
        talentsMarketPanel = transform.Find("TalentsMarketPanel").gameObject;
        companiesPanel = transform.Find("CompaniesPanel").gameObject;
        contractSendPanel = transform.Find("ContractSendPanel").gameObject;
        newsPanel = transform.Find("NewsPanel").gameObject;

        property = bottomPanel.transform.Find("Property").GetComponent<Text>();
        reputation = bottomPanel.transform.Find("Reputation").GetComponent<Text>();
        GDP = bottomPanel.transform.Find("GDP").GetComponent<Text>();
        population = bottomPanel.transform.Find("Population").GetComponent<Text>();
        trend = bottomPanel.transform.Find("Trend").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (City.currentCompany == null) {
            return;
        }
        property.text = City.currentCompany.fund.ToString();
        reputation.text = City.currentCompany.fame.ToString();
        population.text = Population.amount.ToString();
    }

    public void NewsPanelEntry(News news)
    {
        newsPanel.GetComponent<FullScreenPanel>().UIEntry();
        newsPanel.GetComponent<NewsPanel>().OnOpen(news);
    }

    public void TalentsManagePanelEntry()
    {
        talentsManagePanel.GetComponent<FullScreenPanel>().UIEntry();
        talentsManagePanel.GetComponent<TalentManageUI>().OnOpen();
    }

    public void TalentsManagePanelEntry(Talent targetTalent)
    {

        talentsManagePanel.GetComponent<FullScreenPanel>().UIEntry();
        talentsManagePanel.GetComponent<TalentManageUI>().OnOpen(targetTalent);
    }

    public void BlocksManagePanelEntry()
    {
        blocksManagePanel.GetComponent<FullScreenPanel>().UIEntry();
        blocksManagePanel.GetComponent<BuildingManagement>().OnOpen();
    }

    public void BlocksManagePanelEntry(Block targetBlock)
    {
        blocksManagePanel.GetComponent<FullScreenPanel>().UIEntry();
        blocksManagePanel.GetComponent<BuildingManagement>().OnOpen(targetBlock);
    }

    public void TalentsManagePanelExit()
    {
        talentsManagePanel.SetActive(false);
    }

    public void TalentsMarketPanelEntry()
    {
        talentsMarketPanel.GetComponent<FullScreenPanel>().UIEntry();
        talentsMarketPanel.GetComponent<TalentsMarket>().OnOpen();
    }

    public void CompaniesPanelEntry()
    {
        companiesPanel.GetComponent<FullScreenPanel>().UIEntry();
        companiesPanel.GetComponent<CompaniesUI>().OnOpen();
    }

    public void ContractSendPanelEntry(Company other)
    {
        contractSendPanel.GetComponent<FullScreenPanel>().UIEntry();
        contractSendPanel.GetComponent<ContractSendPanel>().OnOpen(City.currentCompany, other);
    }

    public void OnTalentManageButtonClicked()
    {
        TalentsManagePanelEntry();
    }

    public void OnBlockManageButtonClicked()
    {
        BlocksManagePanelEntry();
    }

    public void OnExitButton(Button button)
    {
        button.SendMessageUpwards("UIExit");
    }
}