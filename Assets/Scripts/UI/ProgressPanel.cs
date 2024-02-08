using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ProgressPanel : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Progress;
    public GameObject Head;
    public GameObject LevelText;
    public GameObject Bg;
    public GameObject Flag;
    public GameObject FlagPrefab;
    void Start()
    {
        Progress = transform.Find("Progress").gameObject;
        Head = transform.Find("Head").gameObject;
        Bg=transform.Find("Bg").gameObject;
        LevelText = transform.Find("LevelText").gameObject;
        Flag = transform.Find("Flag").gameObject;
        FlagPrefab = Resources.Load("prefab/UI/Flag") as GameObject;
    }
    public void SetPercent(float per){
        Progress.GetComponent<Image>().fillAmount = per;
        float originPosX = Bg.GetComponent<RectTransform>().position.x + Bg.GetComponent<RectTransform>().sizeDelta.x/2;
        float width = Bg.GetComponent<RectTransform>().sizeDelta.x;
        float offset = 10;
        if(per==1){
            offset=0;
        }
        Head.GetComponent<RectTransform>().position = new Vector2(originPosX - per*width+offset,Head.GetComponent<RectTransform>().position.y);
    }
    public void SetFlagPercant(float per){

        Flag.SetActive(false);
        float originPosX = Bg.GetComponent<RectTransform>().position.x + Bg.GetComponent<RectTransform>().sizeDelta.x/2;
        float width = Bg.GetComponent<RectTransform>().sizeDelta.x;
        float offset = 10;
        if(per==1){
            offset=-5;
        }
        GameObject newFlag = Instantiate(FlagPrefab);
        newFlag.transform.SetParent(gameObject.transform,false);
        newFlag.GetComponent<RectTransform>().position = Flag.GetComponent<RectTransform>().position;
        newFlag.GetComponent<RectTransform>().position = new Vector2(originPosX-per*width+offset,Head.GetComponent<RectTransform>().position.y);
        Head.transform.SetAsLastSibling();
        
    }
    // Update is called once per frame
    void Update()
    {
      
    }
}
