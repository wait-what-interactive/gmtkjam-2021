using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTower : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (TowersController.instance.CanSpawnTower())
        {
            TowersController.instance.IncreaseTowersCount();
            transform.parent.GetChild(1).gameObject.SetActive(true);
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }
    }
}
