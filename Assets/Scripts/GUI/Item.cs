using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Novo Item", menuName = "Inventário/Item")]
public class Item : ScriptableObject
{
    public GameObject itemPrefab;
    public string itemName;
    public Sprite itemIcon; // Ícone do item (pode ser uma imagem)
    public string itemDescription;
    // Outros atributos do item (por exemplo, descrição, peso, etc.)
}
