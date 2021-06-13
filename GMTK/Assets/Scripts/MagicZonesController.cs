using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MagicZone
{
    public List<GameObject> towers = new List<GameObject>();
    public bool wasJoined = false;
}

public class MagicZonesController : MonoBehaviour
{
    public List<MagicZone> magicZones;

    private void Start()
    {
    }

    public void CheckZones()
    {
        for(int i = 0; i < magicZones.Count; ++i)
        {
            bool allTowerActive = false;
            for (int j = 0; j < magicZones[i].towers.Count; ++j)
            {
                if(magicZones[i].towers[j].transform.GetChild(1).gameObject.activeSelf)
                    allTowerActive = true;
                else
                {
                    allTowerActive = false;
                    break;
                }
            }   
            
            if(allTowerActive && !magicZones[i].wasJoined)
            {
                magicZones[i].wasJoined = true;
                //print("is combination");
                for (int j = 0; j < magicZones[i].towers.Count; ++j)
                    magicZones[i].towers[j].transform.GetChild(1).GetComponent<Tower>().isInZone = true;
            }
            else
            {
                if (!allTowerActive && magicZones[i].wasJoined)
                {
                    magicZones[i].wasJoined = false;
                    //print("combination died");
                    for (int j = 0; j < magicZones[i].towers.Count; ++j)
                        magicZones[i].towers[j].transform.GetChild(1).GetComponent<Tower>().isInZone = false;
                }
            }
        }
    }
}
