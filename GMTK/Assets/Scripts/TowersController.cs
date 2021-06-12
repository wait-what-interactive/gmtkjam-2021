using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowersController : MonoBehaviour
{
    public static TowersController instance = null;
    [SerializeField] private int countOfTowers = 0;
    [SerializeField] private int maxCountOfTowers = 5;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {

    }

    public void IncreaseTowersCount()
    {
        if (countOfTowers < maxCountOfTowers)
            countOfTowers++;
    }

    public void DecreaseTowersCount()
    {
        if (countOfTowers > 0)
            countOfTowers--;
    }

    public int GetCountOfTowers()
    {
        return this.countOfTowers;
    }

    public int GetMaxCountOfTowers()
    {
        return this.maxCountOfTowers;
    }
}
