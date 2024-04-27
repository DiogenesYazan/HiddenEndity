using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOpenDoor : MonoBehaviour
{
    public Animator doorAnimator; // Referência ao componente Animator da porta
    public string openTrigger = "Open"; // Nome do trigger para abrir a porta
    public string closeTrigger = "Close"; // Nome do trigger para fechar a porta
    private bool isDoorOpen = false; // Flag para controlar o estado da porta
    private float Delay = 10f; // Delay para fechar a porta após 10 segundos

    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que entrou no trigger é o jogador (ou outro objeto desejado)
        if (other.CompareTag("Player"))
        {
            OpenDoor();
            StartCoroutine(CloseDoorAfterDelay(10f)); // Fecha a porta após 10 segundos
        }
    }

    private void OpenDoor()
    {
        if (!isDoorOpen)
        {
            doorAnimator.SetTrigger(openTrigger); // Ativa o trigger para abrir a porta
            isDoorOpen = true; // Define a porta como aberta
        }
    }

    private System.Collections.IEnumerator CloseDoorAfterDelay(float delay)
    {
        yield return new WaitForSeconds(Delay);
        doorAnimator.SetTrigger(closeTrigger); // Ativa o trigger para fechar a porta
        isDoorOpen = false; // Define a porta como fechada
    }
}