using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public ParticleSystem psDestroy;


    private void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(1))
        {
            SoundManager.instance?.TowerDestroyPlay();
            psDestroy.Play();
            TowersController.instance.DecreaseTowersCount();
            transform.parent.GetChild(0).gameObject.SetActive(true);
            gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("MagicZone").GetComponent<MagicZonesController>().CheckZones();
        }
    }
}
