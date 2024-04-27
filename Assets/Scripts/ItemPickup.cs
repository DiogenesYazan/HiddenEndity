using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item; // Referência ao Scriptable Object do item
    public InventoryManager inventary; // Referência ao inventário

    // Este método é chamado quando o jogador entra no trigger
    private void OnTriggerStay(Collider other){
        if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            Debug .Log("Colidiu com o trigger do item e apertou E");
            Pickup();
        }
    }

    // Método para obter o item associado a este objeto
    public Item GetItem()
    {
        return item;
    }

    // Método para o jogador pegar o item
    void Pickup()
    {
        // Adicione o item ao inventário
        bool wasAdded = inventary.AddItem(item);
        if (wasAdded)
        {
            // Se o item foi adicionado ao inventário, remova o objeto do mundo
            Destroy(gameObject);
        }
    }

    // Implemente outros métodos ou lógica específica para o item, se necessário
}
