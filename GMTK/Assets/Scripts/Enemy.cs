using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float HP;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("bullet"))
        {
            HP -= collision.gameObject.GetComponent<Bullet>().getDamage();
            collision.gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("bullet_container").GetComponent<BulletPull>().addBullet(collision.gameObject);
            if (HP <= 0)
                Destroy(gameObject);
        }
           
    }
    void Update()
    {
        transform.Translate(Vector2.right*Time.deltaTime);
    }
}
