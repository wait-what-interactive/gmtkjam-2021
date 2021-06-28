using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowersController : MonoBehaviour
{
    public static TowersController instance = null;
    [SerializeField] private int countOfTowers = 0;
    [SerializeField] private int maxCountOfTowers = 5;

    public Text towersCount;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        OnTowersCountChange();
    }

    public void OnTowersCountChange()
    {
        GameObject.FindGameObjectWithTag("towers_counter").GetComponent<Text>().text = $"{countOfTowers} / {maxCountOfTowers}";
    }

    public void IncreaseTowersCount()
    {
        if (countOfTowers < maxCountOfTowers)
        {
            countOfTowers++;
            OnTowersCountChange();
        }
    }

    public void DecreaseTowersCount()
    {
        if (countOfTowers > 0)
        {
            countOfTowers--;
            OnTowersCountChange();
        }
    }

    public bool CanSpawnTower()
    {
        return countOfTowers < maxCountOfTowers;
    }
}
