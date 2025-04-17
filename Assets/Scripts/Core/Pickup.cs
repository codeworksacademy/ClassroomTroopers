using UnityEngine;


public enum PickupType
{
    Health,
    Mana,
    Ouchie
}


public class Pickup : MonoBehaviour
{

    public PickupType type;
    public float bobSpeed = 0;
    public float bobHeight = 0;
    public float value = 1f;

    void Update()
    {




    }


    // NOTE                           vvv theThingThatTouchedMe     
    void OnTriggerEnter2D(Collider2D collider)
    {

        var player = collider.GetComponent<Player>();

        if (player == null)
        {
            return;
        }

        // it is the player that touched me!!!
        player.CollectPickup(this);
        Destroy(gameObject);

    }


}
