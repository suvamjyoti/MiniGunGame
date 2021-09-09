using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private Transform gunHold;
    [SerializeField] private GunScriptableObject startingGun;

    private Gun equipedGun;
    private Transform gunGFX;

    [SerializeField] private float m_fireRate;
    private float currentTime = 0;


    private bool _isBursting = false;
    private int noOfBurstRound = 3;

    [SerializeField]private ShootType m_shootType;

    void Start()
    {
        EquipGun(startingGun);
    }


    private void EquipGun(GunScriptableObject _gunConfig)
    {
        if(equipedGun != null)
        {
            Destroy(equipedGun.gameObject);
        }

        Gun gun = gameObject.AddComponent<Gun>();
        gun.SetGunConfig(_gunConfig);

        m_fireRate = 60f/(float)_gunConfig.fireRatePerMinute;
        equipedGun = gun;
        
        gunGFX = Instantiate(_gunConfig.GunGFX, gunHold);
        gunGFX.parent = gunHold;
        
    }

    
    private void Update()
    {
        if (canShoot())
        {
            Shoot();
        }
        else
        {
            currentTime += Time.deltaTime;
        }
    }



    private bool canShoot()
    {
        return (currentTime > m_fireRate && _isBursting == false) ;
    }

    private void Shoot()
    {
        switch (m_shootType)
        {
            case ShootType.Auto:
                if (Input.GetButton("Fire1"))
                {
                    currentTime = 0;
                    equipedGun.Shoot(gunGFX);
                }
                break;

            case ShootType.Semi:
                if (Input.GetButtonDown("Fire1"))
                {
                    currentTime = 0;
                    equipedGun.Shoot(gunGFX);
                }
               
                break;
            case ShootType.Burst:
                if (Input.GetButton("Fire1"))
                {
                    currentTime = 0;
                    StartCoroutine(burstFire());
                }
                break;
        }
    }
    

    private IEnumerator burstFire()
    {
        _isBursting = true;
        int i = 0;
        while (i< noOfBurstRound)
        {
            yield return new WaitForSeconds(m_fireRate);
            equipedGun.Shoot(gunGFX);
            i++;
        }

        yield return new WaitForSeconds(0.5f);

        _isBursting = false;
    }

}
