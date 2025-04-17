using System.Collections.Generic;
using UnityEngine;


public enum WeaponModifiers
{
    [Header("Gun Mods")]
    AttackSpeed,
    BurstCout,
    CycleRate,

    [Header("Projectile Mods")]
    Pierce,
    ProjecileSpeed,
    Damage,
    Scale
}


public class WeaponMod : Pickup
{

    public List<WeaponModifiers> Modifiers;

}
