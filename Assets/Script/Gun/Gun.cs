using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private GunScriptableObject m_gunConfig;

    public void SetGunConfig(GunScriptableObject _gunConfig)
    {
        m_gunConfig = _gunConfig;
    }


    public void Shoot(Transform parent)
    {
        Transform obj = Instantiate(m_gunConfig.bullet.GetComponent<Transform>(), parent);
        Projectile bullet = obj.GetComponent<Projectile>();
        bullet.newSpeed(m_gunConfig.muzzelVelocity);
    }


}
