using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPull : MonoBehaviour
{
    public GameObject bullet;
    public int startBulletCount;

    List<GameObject> bullets;

    void Start()
    {
        bullets = new List<GameObject>();
        for (int i = 0; i < startBulletCount; ++i)
            bullets.Add(Instantiate(bullet, transform));
    }
    
    public GameObject getBullet()
    {
        if (bullets.Count == 0)
            bullets.Add(Instantiate(bullet, transform));

        GameObject bulletGO = bullets[0];
        bullets.RemoveAt(0);
        return bulletGO;
    }

    public void addBullet(GameObject bulletGO)
    {
        bullets.Add(bulletGO);
    }
}
