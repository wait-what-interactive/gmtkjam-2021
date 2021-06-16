using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackZone : MonoBehaviour
{
    List<GameObject> enemies;
    IEnumerator shootController;

    public float cooldown = 1;

    public float koefInZone = 2;
    public float koefColorToSameColor = 1;
    public float koefBlackToColor = 0.5f;
    public float koefColorToOtherColor = 0f;

    public float damage = 25;

    public bool isInZone = false;

    public string curColor;

    void Start()
    {
        enemies = new List<GameObject>();
        shootController = null;
    }

    private void OnTriggerEnter(Collider collision)
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

    private void OnTriggerExit(Collider collision)
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

        //for (int i = enemies.Count - 1; i >= 0; --i)
        //    if (enemies[i] == null)
        //        enemies.RemoveAt(i);

        foreach (var enemy in enemies)
            if (enemy != null && minDistance > Vector3.Distance(enemy.transform.position, transform.position))
            {
                minDistance = Vector3.Distance(enemy.transform.position, transform.position);
                minDistancePosition = enemy.transform.position;
                target = enemy.transform;
            }

        if (minDistancePosition != Vector2.zero)
        {
            minDistancePosition = (minDistancePosition - (Vector2)transform.position).normalized;

            GameObject bulletGO = GameObject.FindGameObjectWithTag("BulletContainer").GetComponent<BulletPull>().getBullet();
            bulletGO.transform.position = transform.position;

            Bullet bul = bulletGO.GetComponent<Bullet>();

            if (curColor == "white")
                bul.setDamage(damage * koefBlackToColor);
            else
            {
                if (curColor == target.GetComponent<Enemy>().getColor())
                    bul.setDamage(damage * koefColorToSameColor);
                else
                    bul.setDamage(damage * koefColorToOtherColor);
            }

            if (isInZone)
                bul.setDamage(bul.getDamage() * koefInZone);

           // print(koefBlackToColor);

            bul.setTarget(target);
            bulletGO.GetComponent<SpriteRenderer>().color = transform.parent.GetComponent<SpriteRenderer>().color;
            bulletGO.SetActive(true);
        }
    }
}
