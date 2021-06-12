using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    List<GameObject> enemies;
    IEnumerator shootController;

    public float cooldown = 1;

    void Start()
    {
        enemies = new List<GameObject>();
        shootController = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("enemy"))
        {
            enemies.Add(collision.gameObject);
            if (shootController == null)
            {
                shootController = Shooting();
                StartCoroutine(shootController);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            if (enemies.Count > 0)
                enemies.Remove(collision.gameObject);

            if (enemies.Count == 0)
            {
                StopCoroutine(shootController);
                shootController = null;
            }
        }
    }

    IEnumerator Shooting()
    {
        while(enemies.Count!=0)
        {
            Shoot();
            yield return new WaitForSeconds(cooldown);
        }
    }

    void Shoot()
    {
        float minDistance = 100;
        Vector2 minDistancePosition = Vector2.zero;

        foreach(var enemy in enemies)
            if(minDistance > Vector3.Distance(enemy.transform.position, transform.position))
            {
                minDistance = Vector3.Distance(enemy.transform.position, transform.position);
                minDistancePosition = enemy.transform.position;
            }

        minDistancePosition = (minDistancePosition - (Vector2)transform.position).normalized;

        GameObject bulletGO = GameObject.FindGameObjectWithTag("bullet_container").GetComponent<BulletPull>().getBullet();
        bulletGO.transform.position = transform.position;
        bulletGO.SetActive(true);
        bulletGO.GetComponent<Bullet>().setDirection(minDistancePosition);
    }
}
