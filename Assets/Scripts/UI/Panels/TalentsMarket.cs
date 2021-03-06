﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalentsMarket : MonoBehaviour
{

    public GameObject talentInfoPrefab;

    private ScrollRect scrollrect;//talents' scroll view
    private GameObject content;//content contains talent informations
    private TalentManageUI talentManageUI;
    private RectTransform contentTR;

    private Color defaultColor;

    //details panel's objects
    private List<Talent> talentMarket;
    private int serial;//displayed talent's serial number in talents list
    private Transform details;
    private Text talentName;
    private Text capacity;
    private Text charm;
    private Text salary;

    // Start is called before the first frame update
    void Start()
    {
        talentInfoPrefab = (GameObject)Resources.Load("Prefabs/UnhiredTalentInfo");
        defaultColor = talentInfoPrefab.GetComponent<Image>().color;

        talentManageUI = GameObject.FindObjectOfType<TalentManageUI>();

        talentMarket = new List<Talent>();

        scrollrect = transform.Find("Talents").GetComponent<ScrollRect>();
        content = transform.Find("Talents").transform.Find("Content").gameObject;
        contentTR = content.GetComponent<RectTransform>();
        contentTR.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 0);

        details = transform.Find("Details");
        talentName = details.Find("Name").GetComponent<Text>();
        capacity = details.Find("Capacity").GetComponent<Text>();
        charm = details.Find("Charm").GetComponent<Text>();
        salary = details.Find("Salary").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DestroyItemInfo()
    {

    }

    public void OnOpen()
    {
        //disable the details panel
        details.gameObject.SetActive(false);

        //clear the previous content
        BroadcastMessage("DestroyItemInfo");
        
        GameObject talentInfo;
        RectTransform rectTransform;
        ItemInfo script;
        int i = 0;//i is the number of column


        talentMarket.Clear();
        foreach(Talent talent in City.talentList)
        {
            if (!talent.isHired)
            {
                talentMarket.Add(talent);
            }
        }

        foreach (Talent talent in talentMarket)
        {
            //add talent's information
            talentInfo = GameObject.Instantiate(talentInfoPrefab, content.transform);
            rectTransform = talentInfo.GetComponent<RectTransform>();
            script = talentInfo.GetComponent<ItemInfo>();

            script.serial = i;

            //set position
            rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, i * 50, 50);

            //set text
            talentInfo.transform.Find("Name").GetComponent<Text>().text = talent.name;
            talentInfo.transform.Find("Salary").GetComponent<Text>().text = talent.salary.ToString();
            talentInfo.transform.Find("Capacity").GetComponent<Text>().text = talent.capacity.ToString();
            talentInfo.transform.Find("Charm").GetComponent<Text>().text = talent.charm.ToString();


            i++;
        }

        //change content rect's height
        contentTR.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, i * 50);
    }

    public void DisplayItemInfo(int _serial)
    {
        this.serial = _serial;
        details.gameObject.SetActive(true);

        //change color of the item selected 
        for (int i = 0; i < contentTR.childCount; i++)
        {
            if (i != serial)
            {
                contentTR.GetChild(i).GetComponent<Image>().color = defaultColor;
            }
            else
            {
                contentTR.GetChild(i).GetComponent<Image>().color = Color.red;
            }
        }

        Talent talent = talentMarket[serial];

        talentName.text = talent.name;
        capacity.text = talent.capacity.ToString();
        charm.text = talent.charm.ToString();
        salary.text = talent.salary.ToString();
    }

    public void OnHireButtonClicked()
    {
        Talent talent = talentMarket[serial];
        City.currentCompany.hireTalent(talent);
        this.OnOpen();
        talentManageUI.OnOpen();
    }
}
