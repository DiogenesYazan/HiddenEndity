using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }

    private void Awake()
    {
        // Se já existe uma instância, e não sou eu mesmo, destruo-me.
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
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

    private List<GameObject> _instantiatedSlots;

    void Start()
    {
        // Inicializa a lista de slots instanciados
        _instantiatedSlots = new List<GameObject>();
        RefreshInventory();
    }

    void RefreshInventory()
    {
        // Destrói os slots existentes
        for (int i = _instantiatedSlots.Count - 1; i >= 0; i--)
        {
            Destroy(_instantiatedSlots[i].gameObject);
        }

        // Limpa a lista de slots instanciados
        _instantiatedSlots.Clear();

        // Re-instancia os slots e adiciona na lista
        foreach (Item inventoryItem in inventoryItems)
        {
            GameObject slot_instance = Instantiate(inv_slot, inv_background.transform);
            slot_instance.GetComponentInChildren<Image>().sprite = inventoryItem.itemIcon;
            slot_instance.GetComponentInChildren<Text>().text = inventoryItem.itemName;
            _instantiatedSlots.Add(slot_instance);
        }
    }

    public bool AddItem(Item newItem)
{
    if (inventoryItems.Count < maxInventorySlots)
    {
        inventoryItems.Add(newItem);
        RefreshInventory(); // Atualize a UI do inventário após adicionar o item
        return true;
    }
    else
    {
        Debug.Log("Inventário cheio! Não é possível adicionar mais itens.");
        return false;
    }
}

}

