using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public GameObject inv_background;
    public GameObject inv_slot;



    public List<Item> inventoryItems = new List<Item>();
        public int maxInventorySlots = 5;

    public bool AddItem(Item newItem)
    {
        if (inventoryItems.Count < maxInventorySlots)
        {
            inventoryItems.Add(newItem);
            return true;
        }
        else
        {
            Debug.Log("Inventário cheio! Não é possível adicionar mais itens.");
            return false;
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        RefreshInventory();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void RefreshInventory()
    {
        int hotkey = 1;
        foreach (Item itemLoop in inventoryItems)
        {
            GameObject slot_instance = Instantiate(inv_slot, inv_background.transform);
            slot_instance.GetComponentInChildren<Image>().sprite = itemLoop.itemIcon;
            slot_instance.GetComponentInChildren<Text>().text = itemLoop.itemName;
            slot_instance.name = hotkey.ToString();
            hotkey++;

        }
    }


    void SelectSlot(int hotkey)
    {
        Item selected_item = inventoryItems[hotkey - 1];
    }
}
