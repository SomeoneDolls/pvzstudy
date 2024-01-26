using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class ZombieNormal : MonoBehaviour
{
    public Vector3 direction = new Vector3(-1, 0, 0);
    public float speed;
    private bool isWork;
    private bool Lost;
    private Animator animator;
    public float damage;
    public float damageInterval = 1.4f;
    public float damageTime;
    public float HP;
    private float currentHP;
    private GameObject head;
    public float timer;
    public bool decelerate;

    // Start is called before the first frame update
    void Start()
    {
        isWork = true;
        animator = GetComponent<Animator>();
        currentHP = HP;
        head = transform.Find("Head").gameObject;
        Lost = true;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (decelerate)
        {
            if (timer > 0)
            {
                speed = 7;
                GetComponent<SpriteRenderer>().color = new Color32(134, 150, 183, 255);
            }
            if (timer <= 0)
            {
                speed = 17;
                GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
                decelerate = false;
            }
        }
        //¼õËÙ´úÂë


        if (isWork)
        {
            transform.position += direction * speed * Time.deltaTime;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Plant")
        {
            isWork = false;
            animator.SetBool("work", false);
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Plant")
        {

            //isWork = false;
            animator.SetBool("work", false);
            damageTime += Time.deltaTime;
            if (damageTime >= damageInterval)
            {
                damageTime = 0;
                Plant plant = collision.GetComponent<Plant>();
                float newHealth = plant.ChangeHealth(-damage);
                if (newHealth <= 0)
                {
                    isWork = false;
                }


            }
        }


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Plant")
        {
            isWork = true;
            animator.SetBool("work", true);
        }
    }

    public void ChangeHealth(float num)
    {
        currentHP = Mathf.Clamp(currentHP + num, 0, HP);
        if (currentHP == 0)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            animator.SetTrigger("Die");
            damage = 0;
            Destroy(gameObject, 0.8f);
        }
        if (currentHP <= 100 && Lost)
        {

            animator.SetBool("Lost", true);
            head.SetActive(true);
            Lost = false;
        }
    }
    public void Decelerate()
    {
        timer = 6;
        decelerate = true;

    }
}
