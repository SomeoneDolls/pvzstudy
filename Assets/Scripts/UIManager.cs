using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static UIManager instance;
    public Text sunNumText;
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
    }public void UpdateUI()
    {
        sunNumText.text = Gamemanager.instance.SunNum.ToString();
    }
}
