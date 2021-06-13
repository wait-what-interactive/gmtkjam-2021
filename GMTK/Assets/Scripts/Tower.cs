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
        if (collision.CompareTag("Enemy"))
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
        if (collision.CompareTag("Enemy"))
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
        while (enemies.Count != 0)
        {
            Shoot();
            yield return new WaitForSeconds(cooldown);
        }
    }

    void Shoot()
    {
        float minDistance = 100;
        Vector2 minDistancePosition = Vector2.zero;
        Transform target = null;

        foreach (var enemy in enemies)
            if (minDistance > Vector3.Distance(enemy.transform.position, transform.position))
            {
                minDistance = Vector3.Distance(enemy.transform.position, transform.position);
                minDistancePosition = enemy.transform.position;
                target = enemy.transform;
            }

        minDistancePosition = (minDistancePosition - (Vector2)transform.position).normalized;

        GameObject bulletGO = GameObject.FindGameObjectWithTag("BulletContainer").GetComponent<BulletPull>().getBullet();
        bulletGO.transform.position = transform.position;
        bulletGO.GetComponent<Bullet>().setTurget(target);
        bulletGO.SetActive(true);
    }

    private void OnMouseOver()
    {
        //  deleting tower
        if (Input.GetMouseButtonDown(1))
        {
            TowersController.instance.DecreaseTowersCount();
            transform.parent.GetChild(0).gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
