using UnityEngine;

namespace KDS._02.Script
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Block : MonoBehaviour
    {
        [SerializeField] private float minImpactVelocity = 3f;
        [SerializeField] private float forceMultiplier = 8f;
        [SerializeField] private float torqueMultiplier = 5f;
        [SerializeField] private float upwardBias = 0.3f;

        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            float impactSpeed = collision.relativeVelocity.magnitude;

            if (impactSpeed < minImpactVelocity) return;

            Vector2 impactDirection = collision.relativeVelocity.normalized;
            impactDirection += Vector2.up * upwardBias;
            impactDirection.Normalize();

            float extraForce = impactSpeed * forceMultiplier;
            _rigidbody.AddForce(impactDirection * extraForce, ForceMode2D.Impulse);

            float torqueDirection = collision.contacts[0].point.x < transform.position.x ? 1f : -1f;
            _rigidbody.AddTorque(torqueDirection * impactSpeed * torqueMultiplier, ForceMode2D.Impulse);
        }
    }
}
