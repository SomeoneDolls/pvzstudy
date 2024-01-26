using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunFlower : Plant
{
    public float readyTime;
    private float timer;
    public GameObject sunPrefab;
    private int sunNum;
    //public float HP;
    //public float currentHP;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        //currentHP = HP;

        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!start)
            return;
        timer += Time.deltaTime;
        if (timer > readyTime)
        { 
            animator.SetBool("light", true);
        }
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void BornSunOver()
    {
        
        animator.SetBool("light", false);
        timer = 0;
    }
    private void BornSun()
    {
        GameObject sunNew = Instantiate(sunPrefab);
        sunNum = Random.Range(1, 50);
        float randomX;
        if (sunNum%2 == 1)
        {
            randomX = Random.Range(transform.position.x - 30, transform.position.x - 20);
        }
       else
        {
            randomX = Random.Range(transform.position.x + 20, transform.position.x + 30);
        }
        sunNew.transform.position = new Vector2(randomX,transform.position.y);

    }
}
