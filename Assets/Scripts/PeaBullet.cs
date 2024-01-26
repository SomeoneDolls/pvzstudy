using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaBullet : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    public float Damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
        if (transform.position.x>=556)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Zombie")
        {
            collision.GetComponent<ZombieNormal>().ChangeHealth(-Damage);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
