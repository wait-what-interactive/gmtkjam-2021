using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTower : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnMouseDown()
    {
        transform.parent.GetChild(1).gameObject.SetActive(true);
        Destroy(gameObject);
    }
}
