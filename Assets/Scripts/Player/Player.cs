using System.Collections;
using UnityEngine;

public class Player : Character
{


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
        // CheckDeath();
    }






}