using System;
using UnityEngine;

namespace SJH
{
    public abstract class AbstractEnemy : MonoBehaviour
    {
        [SerializeField] protected float speedOffset = 1f;
        
        protected virtual void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.layer == 9 && other.transform.TryGetComponent(out Rigidbody2D rigid))
            {
                Debug.Log(rigid.linearVelocity.magnitude);
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
