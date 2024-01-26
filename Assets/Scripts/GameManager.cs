using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    // Start is called before the first frame update
    public static Gamemanager instance;
    public int SunNum;
    public GameObject bornParent;
    public GameObject zombiePrefab;
    public float createZombieTime;
    private int zOrderIndex = 0;
    public LevelData levelData;
    public bool gameStart;
    public int curLevelId = 1;
    public int curProgressId = 1;
    public enum Zombie {
        ZombieNormal
    };
    void Awake()
    {
         instance = this;

    }
    void Start()
    {
       
        UIManager.instance.InitUI();
        CreateZombie();
        ReadTable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void GameStart()
    {
        UIManager.instance.InitUI();
        CreateZombie();
        InvokeRepeating("createSynDown", 10, 10);
        gameStart = true;

    }
    public void ChangeSunNum(int changrNum)
    {
        SunNum += changrNum;
        if(SunNum<=0)
        {
            SunNum = 0;
        }
        UIManager.instance.UpdateUI();

    }
    public void CreateZombie()
    {
        StartCoroutine(DalayCreateZombie());
    }
    public void TableCreatZombie()
    {
        for (int i = 0;i< levelData.LevelDataList.Count; i++)
        {
            LevelItem levelItem = levelData.LevelDataList[i];
            if (levelItem.levelId == curLevelId&&levelItem.progressId==curProgressId)
            {

            }

        }
    }
    void ReadTable()
    {
        StartCoroutine(LoadTable());
    }
    IEnumerator ITableCreateZombie(LevelItem levelItem)
    {
        yield return new WaitForSeconds(levelItem.creatTime);
    }
    IEnumerator LoadTable()
    {
        ResourceRequest request = Resources.LoadAsync("Level");
        yield return request;
        levelData = request.asset as LevelData;
        for (int i = 0; i < levelData.LevelDataList.Count; i++)
        {
            Debug.Log("Êý¾Ý" + levelData.LevelDataList[i].id);
            
        }
        GameStart();
    }
    IEnumerator DalayCreateZombie()
    {
        yield return new WaitForSeconds(createZombieTime);
        GameObject zombie = Instantiate(zombiePrefab);
        int index = Random.Range(0, 5);
        Transform zombieLine = bornParent.transform.Find("born" + index.ToString());
        zombie.transform.parent = zombieLine;
        zombie.transform.localPosition = Vector3.zero;
        zombie.GetComponent<SpriteRenderer>().sortingOrder = zOrderIndex;
        zOrderIndex += 1;
        StartCoroutine(DalayCreateZombie());
    }
}
