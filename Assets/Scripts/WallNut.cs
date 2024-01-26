using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallNut : Plant
{
    //public float HP;
    //public float currentHP;
    //private Animator animator;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        currentHP = HP;
        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!start)
            return;
        animator.SetFloat("HP", currentHP);
        
    }
    //public float ChangeHealth(float num)
    //{
    //    currentHP = Math.Clamp(currentHP + num, 0, HP);
    //    if (currentHP == 0)
    //    {
    //        Destroy(gameObject);
    //    }
    //    return currentHP;

    //}
}
