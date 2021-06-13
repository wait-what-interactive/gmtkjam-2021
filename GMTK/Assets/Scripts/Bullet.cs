using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    float damage;
    public float speed = 10;
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

    public void setDamage(float value)
    {
        damage = value;
    }

    public void setTurget(Transform turg)
    {
        turget = turg;
    }
}
