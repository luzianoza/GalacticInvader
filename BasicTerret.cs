using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTerret : BaseTerret
{
    public float fireRate;
    private float fireTimer;
    public float damage;

    public GameObject bulletPrefeb;
    public Transform muzzle;

    public Animator shootAni;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        fireTimer -= Time.deltaTime;
        base .Update();

        if (fireTimer <= 0f && target != null)
        {
            Shoot();
            fireTimer = 1f / fireRate;
        }
    }

    private void Shoot()
    {
        GameObject go = Instantiate(bulletPrefeb, muzzle.position, Quaternion.identity);
        Bullet bullet = go.GetComponent<Bullet>();
        if (bullet != null)
        {
            shootAni.SetBool("Shoot", true);
            bullet.SetUpBullet(target, damage);
        }
        else
        {
            Destroy(go);
        }
    }
}
