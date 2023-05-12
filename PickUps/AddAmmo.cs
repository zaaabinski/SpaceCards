using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddAmmo : MonoBehaviour
{
    public Pistol PistolGun1;
    public Pistol PistolGun2;
    public Shotgun ShotGun1;
    public Shotgun ShotGun2;
    public Rifle RifleGun1;
    public Rifle RifleGun2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("IsPlayer"))
        {
            PistolGun1.maxBullets += 12;
            PistolGun2.maxBullets += 12;
            ShotGun1.maxBullets += 20;
            ShotGun2.maxBullets += 20;
            RifleGun1.maxBullets += 30;
            RifleGun2.maxBullets += 30;
        }
    }
    
}
