using System.Collections;
using UnityEngine;

public class Player : Character
{
    Gun gun;

    new void Start()
    {
        BaseCharacter = Resources.Load<BaseCharater>("characters/" + PlayerPrefs.GetString("SelectedCharacter"));
        Debug.Log("Player Start " + BaseCharacter?.name);

        base.Start();
        gun = GetComponentInChildren<Gun>();
        gun.ApplyBaseStats(BaseCharacter);
        gun.Player = this;
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
        }

        if (item.type == PickupType.Weapon)
        {
            gun.ApplyUpgrade((WeaponMod)item);
        }
        // CheckDeath();
    }






}