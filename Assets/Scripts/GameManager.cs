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
    [HideInInspector]
    public LevelData levelData;
    [HideInInspector]
    public LevelInfo levelInfo;
    [HideInInspector]
    public PlantInfo plantInfo;
    public bool gameStart;
    public int curLevelId = 1;
    public int curProgressId = 1;
    public enum Zombie
    {
        ZombieNormal,
        no
    }
    public List<GameObject> curProgressZombie;
    void Awake()
    {
        instance = this;

    }
    void Start()
    {
        curProgressZombie = new List<GameObject>();
       
        //CreateZombie();
        ReadData();
        //  UIManager.instance.InitUI();
    }
    void ReadData()
    {
        // StartCoroutine(LoadTable());
        LoadTableNew();
    }
    public void LoadTableNew()
    {
        levelData = Resources.Load("TableData/Level") as LevelData;
        levelInfo = Resources.Load("TableData/LevelInfo") as LevelInfo;
        plantInfo = Resources.Load("TableData/PlantInfo") as PlantInfo;
        GameStart();
        
    }
    IEnumerator LoadTable()
    {
        ResourceRequest request = Resources.LoadAsync("TableData/Level");
        ResourceRequest request1 = Resources.LoadAsync("TableData/LevelInfo");
        ResourceRequest request2 = Resources.LoadAsync("TableData/PlantInfo");
        yield return request;
        yield return request1; 
        yield return request2;
        levelData = request.asset as LevelData;
        levelInfo = request1.asset as LevelInfo;
        plantInfo = request2.asset as PlantInfo;
        GameStart();
    }
    // Update is called once per frame
    void Update()
    {

    }
    private void GameStart()
    {
        UIManager.instance.InitUI();
        gameStart = true;
        CreateZombie();
        InvokeRepeating("createSynDown", 10, 10);
        SoundManager.instance.PlayBGM(Globals.BGM1);


    }
    public void ChangeSunNum(int changrNum)
    {
        SunNum += changrNum;
        if (SunNum <= 0)
        {
            SunNum = 0;
        }
        UIManager.instance.UpdateUI();

    }
    public void CreateZombie()
    {
        //StartCoroutine(DalayCreateZombie());
        curProgressZombie = new List<GameObject>();
        TableCreatZombie();
        UIManager.instance.InitProgrseePanel();
    }
    public void TableCreatZombie()
    {
        bool canCreate = false;
        for (int i = 0; i < levelData.LevelDataList.Count; i++)
        {
            LevelItem levelItem = levelData.LevelDataList[i];
            if (levelItem.levelId == curLevelId && levelItem.progressId == curProgressId)
            {
                StartCoroutine(ITableCreateZombie(levelItem));
                canCreate = true;
            }

        }
        if (!canCreate)
        {
            StopAllCoroutines();
            curProgressZombie = new List<GameObject>();
            gameStart = false;
        }
    }

    IEnumerator ITableCreateZombie(LevelItem levelItem)
    {
        yield return new WaitForSeconds(levelItem.creatTime);
        GameObject zombiePrefab = Resources.Load("Prefab/Zombie/Zombie" + levelItem.zombieType.ToString()) as GameObject;
        GameObject zombie = Instantiate(zombiePrefab);
        Transform zombieLine = bornParent.transform.Find("born" + levelItem.bornPos.ToString());
        zombie.transform.parent = zombieLine;
        zombie.transform.localPosition = Vector3.zero;
        zombie.GetComponent<SpriteRenderer>().sortingOrder = zOrderIndex;
        zOrderIndex += 1;
        curProgressZombie.Add(zombie);
    }
    public void ZombieDie(GameObject gameObject)
    {
        if (curProgressZombie.Contains(gameObject))
        {
            curProgressZombie.Remove(gameObject);
            UIManager.instance.UpdateProgressPanel();
        }
        if (curProgressZombie.Count == 0)
        {
            curProgressId += 1;
            TableCreatZombie();
        }
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
    public int GetPlantLine(GameObject plant)
    {
        GameObject lineObject = plant.transform.parent.parent.gameObject;
        string lineStr = lineObject.name;
        int line = int.Parse(lineStr.Split("line")[1]);
        return line;
    }

}
