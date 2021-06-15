using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTower : MonoBehaviour
{
    public ParticleSystem ps;
    private void Start()
    {
        ps = transform.parent.GetComponentInChildren<ParticleSystem>();
    }
    private void OnMouseDown()
    {
        if (TowersController.instance.CanSpawnTower())
        {
            ps.Play();
            TowersController.instance.IncreaseTowersCount();
            transform.parent.GetChild(1).gameObject.SetActive(true);
            gameObject.SetActive(false);
            //Destroy(gameObject);
            GameObject.FindGameObjectWithTag("MagicZone").GetComponent<MagicZonesController>().CheckZones();
        }
    }
}
