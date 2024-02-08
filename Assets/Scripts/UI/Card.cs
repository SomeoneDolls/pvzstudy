using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour
{
    public GameObject objectPrefab;
    private GameObject curGameObject;
    private GameObject darkBg;
    private GameObject progressBar;
    public float waitTime;
    public int useSun;
    private float timer;
    private float per;

    // Start is called before the first frame update
    void Start()
    {
        darkBg = transform.Find("dark").gameObject;
        progressBar = transform.Find("progress").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        UpdateProgress();
        UpdatebarkBg();
    }
    void UpdateProgress()
    {
        per = Mathf.Clamp(timer/waitTime,0,1);
        progressBar.GetComponent<Image>().fillAmount = 1 - per;
    }
   void UpdatebarkBg()
    {

        if(progressBar.GetComponent<Image>().fillAmount == 0&&Gamemanager.instance.SunNum>=useSun)
        {
            darkBg.SetActive(false);
        }
        else
        {
            darkBg.SetActive(true);
        }
    }
    public void OnBeginDrag(BaseEventData data)
    {
        if (darkBg.activeSelf)
        {
            return;
        }
        PointerEventData pointerEventData = data as PointerEventData;
        curGameObject = Instantiate(objectPrefab);
        curGameObject.transform.position = TranlateScreenToWorld(pointerEventData.position);
        SoundManager.instance.PlaySound(Globals.S_Seedlift);
    }
    public void OnDrag(BaseEventData data)
    {
        if (curGameObject == null)
        {
            return;
        }
        
        PointerEventData pointerEventData = data as PointerEventData;
        curGameObject.transform.position = TranlateScreenToWorld(pointerEventData.position);

    }
    public void OnEndDrag(BaseEventData data)
    {
        
        if (curGameObject == null)
        {
            return;
        }
        PointerEventData pointerEventData=data as PointerEventData;
        
        Collider2D [] col = Physics2D.OverlapPointAll(TranlateScreenToWorld(pointerEventData.position));
        foreach (Collider2D c in col)
        {
            

            if(c.tag == "Land"&&c.transform.childCount==0)
            {
                curGameObject.transform.parent = c.transform;
                curGameObject.transform.localPosition = Vector3.zero;
                curGameObject.GetComponent<Plant>().SetPlantStart();
                SoundManager.instance.PlaySound(Globals.S_Plant);
                curGameObject = null;

                Gamemanager.instance.ChangeSunNum(-useSun);
                timer = 0;

                break;
            }
        }
        if (curGameObject != null)
        {
            GameObject.Destroy(curGameObject);
            curGameObject = null;
        }
    }
    public static Vector3 TranlateScreenToWorld(Vector3 position)
    {
        Vector3 cameraTranslatePos = Camera.main.ScreenToWorldPoint(position);
        return new Vector3(cameraTranslatePos.x, cameraTranslatePos.y, 0);
    }
}
