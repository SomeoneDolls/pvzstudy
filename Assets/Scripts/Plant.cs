using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public float HP;
    public float currentHP;
    protected bool start;
    protected Animator animator;
    protected BoxCollider2D boxCollider2D;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        animator = GetComponent<Animator>();

        currentHP = HP;
        start = false;
        boxCollider2D = GetComponent<BoxCollider2D>();
        animator.speed = 0;
        boxCollider2D.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public float ChangeHealth(float num)
    {
        currentHP = Mathf.Clamp(currentHP + num, 0, HP);
        if (currentHP == 0)
        {
            Destroy(gameObject);
        }
        return currentHP;

    }
    public void SetPlantStart()
    {
        start = true;
        animator.speed = 1;
        boxCollider2D.enabled = true;
    }
}
