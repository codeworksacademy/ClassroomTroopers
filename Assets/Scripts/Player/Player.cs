using UnityEngine;

public class Player : MonoBehaviour
{
    public float Health = 100;
    public float Mana = 100;




    //                               vvv the item I picked up
    public void CollectPickup(Pickup item)
    {

        if (item.type == PickupType.Mana)
        {
            Mana += item.value;
        }

        if (item.type == PickupType.Health)
        {
            Health += item.value;
        }

        if (item.type == PickupType.Ouchie)
        {
            Health -= item.value;
        }


        CheckDeath();

    }


    private void CheckDeath()
    {
        if(Health <= 0){
            
            Destroy(gameObject);
        }
    }



}