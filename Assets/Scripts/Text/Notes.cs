using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Notes : MonoBehaviour
{
    public GameObject panel; // Arraste o CanvasGroup do seu painel para este campo no Inspetor
    private bool isInsideTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) // Substitua "Player" pela tag do seu personagem
        {
            isInsideTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) // Substitua "Player" pela tag do seu personagem
        {
            isInsideTrigger = false;
        }
    }

    private void Update()
    {
        if (isInsideTrigger && Input.GetKeyDown(KeyCode.E))
        {
            // Ativa o painel
            panel.SetActive(!panel.activeSelf);
        }
        else if (!isInsideTrigger && panel.activeSelf)
        {
            // Desativa o painel
            panel.SetActive(!panel.activeSelf);
        }
    }

}
