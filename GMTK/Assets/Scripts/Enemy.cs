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

    public Color color;

    private bool onEnd = false;

    void Start()
    {
        _maxHP = _hp;
        int childCount = transform.GetChild(0).childCount;
        color = transform.GetChild(0).GetChild(childCount - 1).GetComponent<SpriteRenderer>().color;
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Vector2.Distance(transform.position, target.position) < 0.3f)
            ChangeTarget();

        if(!onEnd)
            transform.position = Vector2.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            HP -= collision.gameObject.GetComponent<Bullet>().getDamage();
            collision.gameObject.GetComponent<Bullet>().setTurget(null);
            collision.gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("BulletContainer").GetComponent<BulletPull>().addBullet(collision.gameObject);
            if (HP <= 0)
                Destroy(gameObject);
        }
    }

    private void ChangeTarget()
    {
        if (currentMovePoint != levelPath.Count - 1)
        {
            currentMovePoint += 1;
            target = levelPath[currentMovePoint];
            return;
        }
        onEnd = true;
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

    public Color getColor()
    {
        return color;
    }

    public void SetStats(int damage, float speed, float hp)
    {
        _hp = hp;
        _maxHP = _hp;
        _damage = damage;
        _speed = speed;
    }
}
