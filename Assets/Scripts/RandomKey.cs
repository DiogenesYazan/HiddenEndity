using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomKey : MonoBehaviour
{
    // Lista para armazenar todas as chaves
    public GameObject[] keys;

    void Start()
    {
        // Desativar todas as chaves no início
        foreach (GameObject key in keys)
        {
            key.SetActive(false);
        }

        // Escolher uma chave aleatória para ativar
        int randomIndex = Random.Range(0, keys.Length);
        keys[randomIndex].SetActive(true);
    }
    
}
