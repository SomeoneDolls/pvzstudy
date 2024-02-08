using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllCardPanel : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Bg;
    public GameObject beforCardPrefab;
    public int cardNum;
    void Start()
    {
        cardNum = 40;
        for (int i = 0 ; i<cardNum;i++){
            GameObject beforCard = Instantiate(beforCardPrefab);
            beforCard.transform.SetParent(Bg.transform,false);
            beforCard.name = "Card"+i.ToString();
        }
    }
    public void InitCards(){

        foreach (PlantInfoItem plantInfo in Gamemanager.instance.plantInfo.PlantInfoList)
        {
            Transform cardParent = Bg.transform.Find("Card"+plantInfo.plantId);
            GameObject reallyCard = Instantiate(plantInfo.cardPrefab) as GameObject;
            reallyCard.transform.SetParent(cardParent,false);
            reallyCard.transform.localPosition=Vector2.zero;
            reallyCard.name = "BeforCard";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
