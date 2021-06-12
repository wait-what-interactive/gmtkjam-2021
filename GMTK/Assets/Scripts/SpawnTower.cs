using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTower : MonoBehaviour
{
    private void OnMouseDown()
    {
        transform.parent.GetChild(1).gameObject.SetActive(true);
        Destroy(gameObject);
    }
}
