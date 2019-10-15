using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipLaserCanons : MonoBehaviour
{
    [SerializeField] Transform spawnBoltTop;
    [SerializeField] Transform spawnBoltBottom;
    private bool lastShotWasTop = false; 
    [SerializeField] GameObject bolt;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(lastShotWasTop)
            {
                Instantiate(bolt, spawnBoltBottom.position, spawnBoltBottom.rotation);
                lastShotWasTop = false; 
            }
            else
            {
                Instantiate(bolt, spawnBoltTop.position, spawnBoltTop.rotation);
                lastShotWasTop = true; 
            }
        }
    }
}
