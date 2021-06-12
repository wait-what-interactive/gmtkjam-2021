using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float HP;
  
    private Transform target;
    private List<Transform> levelPath;

    private int currentMovePoint;

    private float _speed = 5f;
    private float _hp = 100f;
    private float _maxHP;
    private int _damage = 1;

    void Start()
    {
        _maxHP = _hp;
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Vector2.Distance(transform.position, target.position) < 0.3f)
            ChangeTarget();

        transform.position = Vector2.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullet"))
        {
            HP -= collision.gameObject.GetComponent<Bullet>().getDamage();
            collision.gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("BulletContainer").GetComponent<BulletPull>().addBullet(collision.gameObject);
            if (HP <= 0)
                Destroy(gameObject);
        }          
    }

    private void ChangeTarget()
    {
        currentMovePoint += 1;
        target = levelPath[currentMovePoint];
    }

    public void SetLevelPath(List<Transform> lp)
    {
        levelPath = lp;
        currentMovePoint = 0;
        target = lp[currentMovePoint];
    }

    public int GetDamage()
    {
        return _damage;
    }

    public void SetStats(int damage, float speed, float hp)
    {
        _hp = hp;
        _maxHP = _hp;
        _damage = damage;
        _speed = speed;
    }
}
