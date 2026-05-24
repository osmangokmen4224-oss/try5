using UnityEngine;

public class ShotGun : MonoBehaviour
{
    [Header("Mermi Ayarları")]
    public GameObject bulletPrefab;   
    public Transform firePoint;       
    public float bulletSpeed = 15f; // Merminin fırlama hızı

    [Header("Atış Özellikleri")]
    public int pelletCount = 6;       
    public float spreadAngle = 15f;   
    public float fireRate = 0.5f;     // Ateş sıklığı (0.5 saniye)
    private float nextFireTime = 0f;

    void Update()
    {
        // Hem klavyeden E tuşu hem de mouse sol tıkı algılar
        if ((Input.GetKeyDown(KeyCode.E) || Input.GetButtonDown("Fire1")) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        // Konsolda tuşun basılıp basılmadığını görmek için test satırı
        Debug.Log("ATEŞ EDİLDİ! TUŞ ALGILANDI!");

        if (bulletPrefab == null || firePoint == null) 
        {
            Debug.LogError("HATA: Mermi Prefab'ı veya FirePoint Sürüklenmemiş!");
            return;
        }

        for (int i = 0; i < pelletCount; i++)
        {
            // Namlunun açısına göre rastgele sapma hesapla
            float randomSpread = Random.Range(-spreadAngle, spreadAngle);
            Quaternion pelletRotation = firePoint.rotation * Quaternion.Euler(0, 0, randomSpread);

            // Mermiyi oluştur
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, pelletRotation);

            // Mermiyi ileri fırlat (Rigidbody2D kullanarak)
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = bullet.transform.right * bulletSpeed;
            }
            else
            {
                Debug.LogWarning("UYARI: Oluşturulan mermide Rigidbody2D bileşeni yok!");
            }
        }
    }
}