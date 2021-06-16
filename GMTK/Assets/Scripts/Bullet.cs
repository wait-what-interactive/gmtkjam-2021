using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    float damage;
    float speed = 5;
    Transform target;

    private Vector2 dir;

    void Update()
    {
        if(target != null)
        {
            dir = ((Vector2)target.position - (Vector2)transform.position).normalized;
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
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

    public void setTarget(Transform targ)
    {
        target = targ;
    }
}
