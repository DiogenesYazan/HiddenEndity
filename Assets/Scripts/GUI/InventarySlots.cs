using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventarySlots : MonoBehaviour
{
    public static InventarySlots Instance { get; private set; }
    private void Awake() 
{ 
    if(Instance != null && Instance != this) 
    { 
        Destroy(this); 
    } 
    else 
    { 
        Instance = this; 
    } 

}



    public GameObject Slot1;
    public bool haveKey = false;


    public void Slot1Button()
    {
        Debug.Log("Slot 1");
        haveKey = true;
    }
}
