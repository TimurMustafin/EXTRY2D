using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour, IWeapon
{
    [SerializeField]
    private GameObject fireBall;
    [SerializeField]
    private Transform firePoint;
   
    public ShepsConfiguration shepsConfiguration;

    IInputSkills inputSkills;

    private void Start()
    {
        inputSkills = GetComponent<IInputSkills>();
        inputSkills.OnFire += Fire;
    }

    public void Fire()
    {
        StartCoroutine(FireBallMoving());
    }

    IEnumerator FireBallMoving()
    {
        Debug.Log("Fire");
        float timer = shepsConfiguration.FireDelay;
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            yield return null;
        }
        GameObject currentFireball = Instantiate(fireBall, firePoint.position, Quaternion.identity);
        Vector3 startDirection = transform.forward;
        timer = shepsConfiguration.FireballLifetime;
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            currentFireball.transform.position += startDirection * shepsConfiguration.FireballSpeed * Time.deltaTime;
            yield return null;
        }
        Destroy(currentFireball);
    }

    
}
