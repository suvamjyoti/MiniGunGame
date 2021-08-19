using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private Transform gunHold;
    [SerializeField] private Gun startingGun;

    private Gun equipedGun;

    
    void Start()
    {

        EquipGun(startingGun);
    }


    private void EquipGun(Gun _gun)
    {
        if(equipedGun != null)
        {
            Destroy(equipedGun.gameObject);
        }

        equipedGun = Instantiate(_gun, gunHold);
        equipedGun.transform.parent = gunHold;

    }

}
