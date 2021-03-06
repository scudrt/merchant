﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BlockInfo:NetMsg
{
    public BlockInfo(Block block=null)
    {
        this.OP = NetOP.block;
        if (block!=null)
        {
            this.Pos_x = block.Pos_x;
            this.Pos_y = block.Pos_y;
            this.companyBelong = block.companyBelong.id;
            if (block.isEmpty == false) {
                this.buildTypeName = block.building.buildingType;
            }

        }
    }
    public int Pos_x { set; get; }
    public int Pos_y { set; get; }
  

    public int companyBelong { set; get; }

    public string buildTypeName { set; get; }

    public void SetData()
    {
        Debug.Log("同步进行中");
        int n = (int)Mathf.Sqrt((float)City.BLOCK_NUMBER);
        int blockIndex = n * Pos_x + Pos_y;
        Block cur_block = City.blockList[blockIndex];
        cur_block.build(buildTypeName);
    }
}



