using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public ParticleSystem psDestroy;
    private AtackZone atackZone;
    
    private void Start() {
        atackZone = GetComponentInChildren<AtackZone>();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(1) && Time.timeScale > 0f)
        {
            SoundManager.instance?.TowerDestroyPlay();
            psDestroy.Play();
            TowersController.instance.DecreaseTowersCount();
            transform.parent.GetChild(0).gameObject.SetActive(true);
            gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("MagicZone").GetComponent<MagicZonesController>().CheckZones();
            atackZone.ResetState();
        }
    }
}
