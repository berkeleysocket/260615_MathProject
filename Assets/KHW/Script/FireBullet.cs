using System;
using TMPro;
using UnityEngine;

namespace Assets.KHW.Script 
{
    public class FireBullet : MonoBehaviour
    {
        [SerializeField] private TMP_InputField inputAngleField;
        [SerializeField] private TMP_InputField inputPowerField;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform firePos;
        [SerializeField] private int direction = 1;
        private int power = 1;

        public event Action Error;


        public void Fire()
        {
            if (!int.TryParse(inputAngleField.text, out int anlge) || !int.TryParse(inputPowerField.text, out power))
            {
                Error?.Invoke();
                return;
            }


            float rad = anlge * Mathf.Deg2Rad;
            GameObject bullet = Instantiate(bulletPrefab, firePos.position, Quaternion.identity);

            Rigidbody2D bulletrb = bullet.GetComponent<Rigidbody2D>();

            Vector2 dir = new Vector2
            (
                Mathf.Cos(rad) * direction,
                Mathf.Sin(rad)
            );

            bulletrb.AddForce( dir * power,ForceMode2D.Impulse);
        }
    }
}
