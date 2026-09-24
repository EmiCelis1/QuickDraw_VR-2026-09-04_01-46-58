using UnityEngine;
using UnityEngine.Pool;

public class BulletManager : MonoBehaviour
{
    public static BulletManager Instance { get; private set; }

    [Header("Configuración")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int defaultCapacity = 20;
    [SerializeField] private int maxCapacity = 100;

    private IObjectPool<GameObject> pool;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else { Destroy(gameObject); return; }

        
        pool = new ObjectPool<GameObject>(
            createFunc: CreateBullet,
            actionOnGet: OnGetBullet,
            actionOnRelease: OnReleaseBullet,
            actionOnDestroy: OnDestroyBullet,
            collectionCheck: true,
            defaultCapacity: defaultCapacity,
            maxSize: maxCapacity
        );
    }

   
    private GameObject CreateBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab);
        return bullet;
    }

    
    private void OnGetBullet(GameObject bullet)
    {
        bullet.SetActive(true);
    }

    
    private void OnReleaseBullet(GameObject bullet)
    {
        bullet.SetActive(false);
    }

    
    private void OnDestroyBullet(GameObject bullet)
    {
        Destroy(bullet);
    }

    
    public GameObject GetBullet()
    {
        return pool.Get();
    }

    
    public void ReturnBullet(GameObject bullet)
    {
        pool.Release(bullet);
    }
}