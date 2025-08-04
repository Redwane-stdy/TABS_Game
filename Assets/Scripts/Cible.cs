using UnityEngine;
using System.Collections;
public class Cible : MonoBehaviour
{
    [Header("Health Settings")]
    public float health = 1000f; // Points de vie initiaux

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log($"{gameObject.name} a été touché ! Points de vie restants : {health}");

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log($"{gameObject.name} est détruit !");
        Destroy(gameObject); // Détruire l'objet
    }
}

