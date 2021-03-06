﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Company:MonoBehaviour{
    public int id { get; set; }
    public string nickName { get; set; }
    public float fund { get; set; }
    public float fame{get; set;}
    public Color companyColor { get; set; }
    public bool isAlive { get; set; } //TO BE DONE
    public bool isHuman;

    public Contract contract;
    public List<Block> blockList;
    public List<Talent> talentList;

    private static int playerCount = -1;
    

    void Start(){
        this.onGenerate();
    }

    private void onGenerate() {
        id = ++playerCount;
        fund = 1000000f;
        fame = 50f;

        isAlive = true;
        isHuman = false;

        contract = null;
        blockList = new List<Block>();
        talentList = new List<Talent>();

        nickName = "玩家" + id;

        Debug.Log("Company " + id + " init done");
    }
    public bool buyBlock(Block block) {
        //return false if block buying failed
        if (block == null) {
            return false;
        }
        if (block.isOwned || this.fund < block.price) {
            return false;
        }
        fund -= block.price;
        block.companyBelong = this;
        blockList.Add(block);
        return true;
    }

    public bool hireTalent(Talent talent) {
        if (talent.companyBelong != null) {
            return false;
        }
        talent.companyBelong = this;
        talentList.Add(talent);
        return true;
    }

    public bool fireTalent(Talent talent) {
        if (talent.companyBelong != this) {
            return false;
        }
        talent.workPlace = null;
        talent.companyBelong = null;
        this.talentList.Remove(talent);
        return true;
    }

    public bool costMoney(float delta) {
        //return true if it have enough money
        if (delta > this.fund) {
            return false;
        }
        this.fund -= delta;
        return true;
    }

    public bool earnMoney(float delta) {
        return this.costMoney(-delta);
    }

    public bool buildOnBlock(Block block, string buildingType = "Sword") {
        //return false if building buying failed
        if (block.companyBelong != this) {
            return false;
        }
        bool flag = block.build(buildingType);
        return flag;
    }

    public bool canBuildOn(Block block){ // if can build, return true and spend money
        return block.isEmpty && this.fund >= block.building.price;
    }

    // Update is called once per frame
  
}
