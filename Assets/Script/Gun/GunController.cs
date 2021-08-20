using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private Transform gunHold;
    [SerializeField] private GunScriptableObject startingGun;

    private Gun equipedGun;
    private Transform gunGFX;


    
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

        equipedGun = gun;
        
        gunGFX = Instantiate(_gunConfig.GunGFX, gunHold);
        gunGFX.parent = gunHold;
        
    }


    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            equipedGun.Shoot(gunGFX);
        }
    }

}
