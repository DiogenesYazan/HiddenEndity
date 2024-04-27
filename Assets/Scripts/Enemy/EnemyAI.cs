using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;

public class Monster : MonoBehaviour
{
    public float fieldOfView = 110f; // Define o campo de visão
    public bool playerInSight; // O jogador está visível?
    public GameObject player; // Referência ao jogador
    public float maxDistance = 10f; // Distância máxima para o jogador ser seguido
    public float wanderRadius = 10f; // Raio para o inimigo andar aleatoriamente

    public Animator animator; // Referência ao Animator

    private NavMeshAgent nav; // Referência ao componente NavMeshAgent
    private bool isWandering = false;
    private Vector3 lastKnownPlayerPosition; // Última posição conhecida do jogador

    void Awake ()
    {
        // Configura as referências
        player = GameObject.FindGameObjectWithTag("Player");
        nav = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>(); // Configura a referência ao Animator

        // Ajusta a velocidade do inimigo
        nav.speed = 3.5f;
    }

    void Update ()
    {
        // Calcula a direção do jogador
        Vector3 direction = player.transform.position - transform.position;
        float angle = Vector3.Angle(direction, transform.forward);

        // Se o ângulo entre a frente do inimigo e o jogador for menor que metade do campo de visão...
        if(angle < fieldOfView * 0.5f)
        {
            RaycastHit hit;

            // ... e se um raio lançado em direção ao jogador não atingir nada...
            if(Physics.Raycast(transform.position + transform.up, direction.normalized, out hit, maxDistance))
            {
                // ... o jogador está à vista
                if(hit.collider.gameObject == player)
                {
                    playerInSight = true;
                    lastKnownPlayerPosition = player.transform.position;
                    // ... ataca.
                    nav.SetDestination(player.transform.position);
                    nav.speed = 3.5f;
                    animator.speed = 1;
                    animator.SetFloat("Speed", 1f); // Inicia a animação de correr
                    return;
                }
            }
        }

        playerInSight = false;
        // ... anda aleatoriamente pelo cenário.
        if (!isWandering)
        {
            StartCoroutine(Wander());
        }
    }

    IEnumerator Wander()
    {
        isWandering = true;
        // Primeiro, verifica a última posição conhecida do jogador
        nav.SetDestination(lastKnownPlayerPosition);
        nav.speed = 2f;
        animator.speed = 1;
        animator.SetFloat("Speed", 0.5f); // Inicia a animação de andar
        yield return new WaitForSeconds(6);

        // Depois, começa a andar aleatoriamente
        Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
        nav.SetDestination(newPos);
        nav.speed = 1f;
        animator.speed = 1;
        animator.SetFloat("Speed", 0.5f);
        yield return new WaitForSeconds(6);

        // Para por 2 segundos
        //nav.isStopped = true;
        //animator.SetFloat("Speed", 0); // Inicia a animação de idle
        //yield return new WaitForSeconds(2);

        // Continua a andar
        nav.isStopped = false;
        isWandering = false;
        animator.SetBool("Attack", false);
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Colidiu com o trigger do inimigo");
            nav.isStopped = true;
            isWandering = false;
            animator.SetBool("Attack", true);
        }
    }
   
}


