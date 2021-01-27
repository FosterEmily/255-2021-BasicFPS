using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
 public void PlayerInteract()
    {
        Inventory.main.hasKey = true;
        //remeber we picked up the object

        Destroy(gameObject);
    }
 
}
