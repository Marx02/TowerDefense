﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    public Transform target;

    [Header("Attributes")]

    public float range = 4f;
    public float fireRate = 1f;
    private float fireCountDown = 0f;

    [Header("Unity Setup Fields")]

    public string enemyTag = "Enemy";

    public GameObject bulletPrefab;
    public Transform firePoint;


    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);  
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    private void Update()
    {

        if (target == null)
            return;

        if(fireCountDown <= 0f)
        {
            Shoot();
            fireCountDown = 1f / fireRate;
        }

        fireCountDown -= Time.deltaTime;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void Shoot()
    {
        GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(target);
    }
}
