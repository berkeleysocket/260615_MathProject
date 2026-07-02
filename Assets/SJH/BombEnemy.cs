using System;
using UnityEngine;

namespace SJH
{
    public class BombEnemy : AbstractEnemy
    {
        [SerializeField] private ParticleSystem[] bombEffects;
        [SerializeField] private Vector2 explodeRange;
        [SerializeField] private LayerMask whatIsEnemy;
        
        private Collider2D myCollider;

        private void Awake()
        {
            myCollider = GetComponent<Collider2D>();
        }

        public override void EnemyDead()
        {
            myCollider.enabled = false;
            foreach (ParticleSystem particle in bombEffects)
            {
                particle.Play();
            }
            
            Collider2D[] inRange = Physics2D.OverlapBoxAll((Vector2)transform.position, explodeRange, 0, whatIsEnemy);

            foreach (Collider2D col in inRange)
            {
                if (col.TryGetComponent(out AbstractEnemy enemy))
                    enemy.EnemyDead();
            }
            base.EnemyDead();
        }
    }
}