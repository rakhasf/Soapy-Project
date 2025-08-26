using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    private HealthManager health;

    void Start()
    {
        health = GetComponent<HealthManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        int damageAmount = 1;

        
            if (other.CompareTag("Dusty"))
            {
                health.TakeDamage(damageAmount);
            }
            else if (other.CompareTag("Bactino"))
            {
                Destroy(other.gameObject);
                PointManager.Instance.AddScore(10);
            }
      
    }
}