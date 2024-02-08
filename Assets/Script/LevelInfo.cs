using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[CreateAssetMenu(menuName = "SomeoneDolls/LevelInfo",fileName ="LevelInfo",order =2)]
public class LevelInfo: ScriptableObject
{
    public List<LevelInfoItem> LevelInfoList = new List<LevelInfoItem>();
}

[System.Serializable]
public class LevelInfoItem
{
    public int levelId;
    public string levelName;
    public float [] progressPercent;



}