using System;
using UnityEngine;

namespace SJH
{
    public abstract class AbstractEnemy : MonoBehaviour
    {
        [SerializeField] protected float speedOffset = 1f;
        
        protected virtual void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player") && other.transform.TryGetComponent(out Rigidbody2D rigid))
            {
                if(rigid.linearVelocity.magnitude > speedOffset)
                    EnemyDead();
            }
        }

        public virtual void EnemyDead()
        {
            Destroy(gameObject);
        }
    }
}
