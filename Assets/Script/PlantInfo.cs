using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[CreateAssetMenu(menuName = "SomeoneDolls/PlantInfo",fileName ="PlantInfo",order =1)]
public class PlantInfo: ScriptableObject
{
    public List<PlantInfoItem> PlantInfoList = new List<PlantInfoItem>();
}

[System.Serializable]
public class PlantInfoItem
{
    public int plantId;
    public string plantName;
    public string description;
    public GameObject cardPrefab;
    // public int useNum;
    // public int cdTime;
    // public GameObject prefab;
    // public float [] progressPercent;
    override
    public string ToString()
    {
        return "[id]"+plantId.ToString();
    }


}