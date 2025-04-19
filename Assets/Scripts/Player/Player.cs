using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Character
{

    public BaseCharacter BaseCharacter;
    public Gun gun;



    public new void Start()
    {
        var prefabName = PlayerPrefs.GetString("SelectedCharacter", "Soldier");
        if (prefabName == null)
        {
            Debug.Log("no prefab");
            return;
        }

        BaseCharacter = Resources.Load<BaseCharacter>("characters/" + prefabName);

        base.Start();

        MoveSpeed = BaseCharacter.MoveSpeed;
        animator.runtimeAnimatorController = BaseCharacter.Animator;
        gun.ApplyBaseStats(BaseCharacter);

        OnHealthChange += CheckDeath;
    }


    void CheckDeath()
    {
        if (Health <= 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }




    //                               vvv the item I picked up
    public void CollectPickup(Pickup item)
    {

        if (item.type == PickupType.Mana)
        {
            Shield += item.value;
        }

        if (item.type == PickupType.Health)
        {
            Health += item.value;
        }

        if (item.type == PickupType.Ouchie)
        {
            Health -= item.value;
            OnHealthChange?.Invoke();
        }

    }






}