using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaShooter : Plant
{
    public float interval;
    public float time;
    public GameObject bullet;
    public Transform bulletPos;

    //public float HP;
    //public float currentHP;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        //currentHP = HP;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!start )
         return;
        time += Time.deltaTime;
        if(time >= interval)
        {
            time = 0;
            Instantiate(bullet, bulletPos.position, Quaternion.identity);
        }
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
