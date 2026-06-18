using System;
using UnityEngine;

namespace SJH
{
    public abstract class AbstractEnemy : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                EnemyDead();
            }
        }

        protected virtual void EnemyDead()
        {
            Destroy(gameObject);
        }
    }
}
