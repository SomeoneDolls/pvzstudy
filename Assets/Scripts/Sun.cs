using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Sun : MonoBehaviour
{
    public float timer;
    private new float light;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        light = Mathf.Sin(timer* speed)+1.4f;
        if (timer>3)
        {
            GetComponent<SpriteRenderer>().color = new Color(255,255,255,light);
            Destroy(gameObject,5f);
        }
    }
    private void OnMouseDown()
    {
        GameObject.Destroy(gameObject);
        Gamemanager.instance.ChangeSunNum(50);
    }
}
