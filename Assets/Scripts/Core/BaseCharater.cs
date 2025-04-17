using UnityEngine;

[CreateAssetMenu(fileName = "BaseCharacter", menuName = "ScriptableObjects/BaseCharacter", order = 1)]
public class BaseCharater : ScriptableObject
{

    [Header("Base Character Stats")]
    public string Name = "";
    public float Health = 100;
    public float Shield = 0;
    public float MoveSpeed = 2;
    public Sprite Sprite;
    public RuntimeAnimatorController AnimatorController;

    [Header("Gun Stats")]
    public float AttackSpeed = 2;
    public Projectile ProjectilePrefab;
    public float Spread = 0f;
    public float BurstCout = 1;
    public float CycleRate = 0;

    [Header("Projectile Mods")]
    public float PierceMod = 0;
    public float DamageMod = 0;
    public float ProjectileSpeedMod = 0;
    public float ScaleMod = 1;
}
