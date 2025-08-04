// Unit.cs
using UnityEngine;

public class Unit : MonoBehaviour
{


    public static bool game_not_started = true;

    public int cost;
    public float health = 100f;
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log($"{gameObject.name} est mort.");
        Destroy(gameObject);
    }
}