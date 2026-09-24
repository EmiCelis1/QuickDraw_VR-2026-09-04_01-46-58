using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float lifetime = 2f;
    private Coroutine returnCoroutine;
    private bool isReturning = false; 

    void OnEnable()
    {
        
        isReturning = false;

        
        returnCoroutine = StartCoroutine(ReturnRoutine());
    }

    IEnumerator ReturnRoutine()
    {
        yield return new WaitForSeconds(lifetime);
        Deactivate();
    }

    void OnCollisionEnter(Collision collision)
    {
        Deactivate();
    }

    private void Deactivate()
    {
        
        if (isReturning) return;

        isReturning = true; 

        
        if (returnCoroutine != null)
        {
            StopCoroutine(returnCoroutine);
        }

        
        BulletManager.Instance.ReturnBullet(gameObject);
    }
}