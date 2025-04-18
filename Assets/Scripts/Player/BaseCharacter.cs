using UnityEditor.Animations;
using UnityEngine;


[CreateAssetMenu(fileName = "Charcter", menuName = "Drop Troopers/Characters", order = 1)]
public class BaseCharacter : ScriptableObject
{
    [Header("Character Info")]
    public string CharacterName;
    public string Description;
    public Sprite Icon;

    public RuntimeAnimatorController Animator;


    [Header("Charter Stats")]
    public float MoveSpeed = 3;
    public float Health = 100;



    [Header("Gun Modifications")]
    public float Spread = 0;
    public float AttackSpeed = 1;
    public float BurstCount = 1;
    public float CycleTime = .25f;


    [Header("Base Projectile Stats")]
    public Projectile projectilePrefab;
    public float ProjectileSpeed = 10;
    public float Pierce = 0;
    public float Damage = 0;
    public float lifetime = 0;

}
