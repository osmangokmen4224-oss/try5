using UnityEngine;

public class ShotGun
{
    using UnityEngine;

public class ShotGun : MonoBehaviour
{
    [Header("Mermi Ayarları")]
    public GameObject bulletPrefab;   // Mermi objeni buraya sürükle
    public Transform firePoint;       // Merminin çıkacağı namlu ucu

    [Header("Atış Özellikleri")]
    public int pelletCount = 6;       // Saçma sayısı
    public float spreadAngle = 10f;   // Saçılma açısı
    public float fireRate = 0.8f;     // Ateş hızı (sn cinsinden)
    public float bulletSpeed = 15f;   // Mermi hızı
    
    private float nextFireTime = 0f;

    void Update()
    {
        // E tuşuna basıldığında ve süre dolduğunda ateş et
        if (Input.GetKeyDown(KeyCode.E) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        if (bulletPrefab == null || firePoint == null) return;

        for (int i = 0; i < pelletCount; i++)
        {
            // Namlunun açısına göre rastgele sapma hesapla
            float randomSpread = Random.Range(-spreadAngle, spreadAngle);
            Quaternion pelletRotation = firePoint.rotation * Quaternion.Euler(0, 0, randomSpread);

            // Mermiyi oluştur
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, pelletRotation);

            // Mermiyi ileri fırlat
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = bullet.transform.right * bulletSpeed;
            }
        }
    }
}