using UnityEngine;

namespace SJH
{
    public class BombEnemy : AbstractEnemy
    {
        [SerializeField] private ParticleSystem[] bombEffects;
        [SerializeField] private float explodeRange;
        public override void EnemyDead()
        {
            foreach (ParticleSystem particle in bombEffects)
            {
                particle.Play();
            }
            
            Collider2D[] inRange = Physics2D.OverlapCircleAll(transform.position, explodeRange);

            foreach (Collider2D col in inRange)
            {
                if (col.TryGetComponent(out AbstractEnemy enemy))
                    enemy.EnemyDead();
            }
            base.EnemyDead();
        }
    }
}