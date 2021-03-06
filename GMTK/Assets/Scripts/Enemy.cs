using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public string color;

    private bool onEnd = false;

    private ParticleSystem hurt;
    private Exit exit;
    public GameObject deathParticles;

    private GameObject _winText;

    private LevelManager levelManager;

    void Start()
    {
        _maxHP = _hp;
        hurt = GetComponentInChildren<ParticleSystem>();
        levelManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelManager>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Vector2.Distance(transform.position, target.position) < 0.3f)
            ChangeTarget();

        if (!onEnd)
            transform.position = Vector2.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            hurt.Play();
            HP -= collision.gameObject.GetComponent<Bullet>().getDamage();
            collision.gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("BulletContainer").GetComponent<BulletPull>().addBullet(collision.gameObject);
            if (HP <= 0)
            {
                GameObject deathPart = Instantiate(deathParticles, hurt.gameObject.transform.position, Quaternion.identity);
                Destroy(deathPart, 0.7f);
                levelManager.DecreaseEnemies();
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            collision.gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("BulletContainer").GetComponent<BulletPull>().addBullet(collision.gameObject);
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

    public string getColor()
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
