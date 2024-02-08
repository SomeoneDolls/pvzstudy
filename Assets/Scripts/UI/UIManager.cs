using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static UIManager instance;
    public Text sunNumText;
    public ProgressPanel progressPanel;
    public AllCardPanel allCardPanel;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void InitUI()
    {
        sunNumText.text = Gamemanager.instance.SunNum.ToString();
        progressPanel.gameObject.SetActive(false);
        
    }
    public void UpdateUI()
    {
        sunNumText.text = Gamemanager.instance.SunNum.ToString();
    }
    public void InitProgrseePanel(){
        
        LevelInfoItem levelInfo = Gamemanager.instance.levelInfo.LevelInfoList[Gamemanager.instance.curLevelId];
        for (int i = 0; i < levelInfo.progressPercent.Length; i++)
        {
            float percent = levelInfo.progressPercent[i];
            progressPanel.SetFlagPercant(percent);
            if(percent == 1)
            {
                continue;
            }
            
        }
         allCardPanel.InitCards();
        progressPanel.SetPercent(0);
        progressPanel.gameObject.SetActive(true);
       
    }
    public void UpdateProgressPanel(){
        int progressNum = 0 ;
        for (int i = 0; i < Gamemanager.instance.levelData.LevelDataList.Count; i++)
        {
            LevelItem levelItem = Gamemanager.instance.levelData.LevelDataList[i];
            if(levelItem.levelId==Gamemanager.instance.curLevelId&&levelItem.progressId == Gamemanager.instance.curLevelId){
                progressNum+=1;
            }
        }
        

        int remainNum = Gamemanager.instance.curProgressZombie.Count;
        float percent = (float)(progressNum-remainNum)/progressNum;
        
        LevelInfoItem levelInfoItem = Gamemanager.instance.levelInfo.LevelInfoList[Gamemanager.instance.curLevelId];
        float progressPercent = levelInfoItem.progressPercent[Gamemanager.instance.curProgressId - 1];
        float lastProgressPercent = 0;
        
        if (Gamemanager.instance.curProgressId > 1){
            lastProgressPercent = levelInfoItem.progressPercent[Gamemanager.instance.curProgressId - 2];
        }
        
        float finalPercent = percent*(progressPercent - lastProgressPercent)+lastProgressPercent;
        Debug.Log(finalPercent);
        progressPanel.SetPercent(finalPercent);
    }
}
