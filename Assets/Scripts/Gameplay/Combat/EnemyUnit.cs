using UnityEngine;

namespace ProjectNyx
{
    public class EnemyUnit : MonoBehaviour, IDamageable
    {
        [SerializeField] private int maxHealth = 3;
        private int currentHealth;

        public int CurrentHealth => currentHealth;

        private void Start()
        {
            currentHealth = maxHealth;
        }

        public void TakeDamage(int amount)
        {
            currentHealth -= amount;

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                Die();
            }
        }

        private void Die()
        {
            Destroy(gameObject);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position, 0.5f);
        }
    }
}
