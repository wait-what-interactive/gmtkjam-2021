using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    float damage;
    float speed = 5;

    private Vector2 dir;

    void Update()
    {
        transform.Translate(dir * Time.deltaTime * speed);
    }

    public float getDamage()
    {
        return damage;
    }

    public void setDirection(Vector2 dir)
    {
        this.dir = dir;
    }
}
