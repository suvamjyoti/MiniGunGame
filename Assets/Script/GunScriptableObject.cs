using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="GunScriptableObject", menuName ="ScriptableObject/gun")]
public class GunScriptableObject : ScriptableObject
{
    public GunType gunType;
    public Transform GunGFX;

    public Projectile bullet;

    public float muzzelVelocity;
    public int fireRatePerMinute;
    public int bulletPerMagzine;
    public int damage;
    public int range;
}
