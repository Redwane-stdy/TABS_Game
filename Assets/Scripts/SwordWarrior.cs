using UnityEngine;
using UnityEngine.AI;

public class SwordWarrior : Unit
{
    [Header("AI Settings")]
    public NavMeshAgent agent; // NavMeshAgent pour les déplacements
    public Animator animator; // Animator pour les animations

    [Header("Stats")]
    // Points de vie
    public float attackDamage = 25f; // Dégâts infligés
    public float attackRange = 3f; // Portée de l'attaque
    public float attackCooldown = 1.5f; // Temps entre les attaques

    [Header("Chase Settings")]
    public float chaseDistanceMin = 3f;  // Distance minimale pour commencer la poursuite
    public float chaseDistanceMax = 100f; // Distance maximale pour continuer la poursuite

    private GameObject target; // Cible actuelle
    private float lastAttackTime; // Temps du dernier coup
    private float distanceToTarget; // Distance entre le paysan et la cible

    void Update()
    {
        if (target == null)
        {
            Debug.Log("Target not found");
            FindNewTarget();
            if (target != null)
                {
                    Debug.Log($"New target found: {target.name}");
                }
            Idle();
            return;
        }

        distanceToTarget = Vector3.Distance(transform.position, target.transform.position);

        // Gérer les animations de marche ou d'arrêt
        float speed = agent.velocity.magnitude;
        float normalizedSpeed = speed / agent.speed;
        animator.SetFloat("ForwardSpeed", normalizedSpeed);


        // Si le jeu n'a pas commencé, arrêter
        if (Unit.game_not_started == true)
        {
            Idle();
            return;
        }

        // Si la cible est à portée, attaquer
        if (distanceToTarget <= attackRange)
        {
            AttackTarget();
        }
        // Sinon, poursuivre si dans la plage de poursuite
        else if (distanceToTarget > chaseDistanceMin && distanceToTarget < chaseDistanceMax)
        {
            ChaseTarget();
        }
        else
        {
            Idle(); // Hors de portée, arrêter
        }
    }

    void ChaseTarget()
    {
        agent.isStopped = false;
        agent.SetDestination(target.transform.position);
        transform.LookAt(target.transform.position);
    }

    void AttackTarget()
    {
        agent.isStopped = true; // Stopper le mouvement pour attaquer
        animator.SetFloat("ForwardSpeed", 0); // Arrêter l'animation de marche

        if (Time.time - lastAttackTime >= attackCooldown)
        {
            lastAttackTime = Time.time;
            animator.SetTrigger("Attack"); // Lancer l'animation d'attaque
            if (target != null)
        {
            Unit targetUnit = target.GetComponent<Unit>();
            if (targetUnit != null)
            {
                targetUnit.TakeDamage(attackDamage);
                Debug.Log($"{gameObject.name} inflige {attackDamage} dégâts à {target.name}. PV restants : {targetUnit.health}");
            }
            else
            {
                Debug.LogWarning("La cible n'a pas de composant Unit.");
            }
        }
        else
        {
            Debug.LogWarning("Pas de cible disponible pour attaquer.");
        }
        }
    }

    void Idle()
    {
        agent.isStopped = true;
        animator.SetFloat("ForwardSpeed", 0); // Animation Idle
    }


    void FindNewTarget()
    {
        // Trouver tous les objets avec le tag "Cible"
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Cible");
        float closestDistance = Mathf.Infinity;
        GameObject closestTarget = null;

        // Chercher l'objet le plus proche
        foreach (GameObject potentialTarget in targets)
        {
            float distance = Vector3.Distance(transform.position, potentialTarget.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestTarget = potentialTarget;
            }
        }

        // Assigner la cible la plus proche
        target = closestTarget;
    }
}