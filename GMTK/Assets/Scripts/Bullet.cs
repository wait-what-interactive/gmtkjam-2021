using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    float damage;
    float speed = 5;
    Transform turget;

    private Vector2 dir;

    void Update()
    {
        if(turget != null)
        {
            dir = ((Vector2)turget.position - (Vector2)transform.position).normalized;
            transform.Translate(dir * Time.deltaTime * speed);
        }
        else
        {
            gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("BulletContainer").GetComponent<BulletPull>().addBullet(gameObject);
        }
    }

    public float getDamage()
    {
        return damage;
    }

    public void setTurget(Transform turg)
    {
        turget = turg;
    }
}
