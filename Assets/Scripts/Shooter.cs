using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    const string PROJECTILE_PARENT_NAME = "Projectiles";

    [SerializeField] GameObject projectile;
    [SerializeField] GameObject weapon;
    AttackerSpawner spawner;
    Animator animator;
    GameObject projectileParent;

    // Start is called before the first frame update
    void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
        CreateProjectileParent();
    }

    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);

        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("IsAttacking", IsAttackerInLane());
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] attackerSpawners = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner attackerSpawner in attackerSpawners)
        {
            if (Mathf.Abs(attackerSpawner.transform.position.y - transform.position.y) <= Mathf.Epsilon)
            {
                spawner = attackerSpawner;

                break;
            }
        }
    }

    private bool IsAttackerInLane()
    {
        return spawner.transform.childCount > 0;
    }

    public void Fire()
    {
        GameObject newProjectile = Instantiate(projectile, weapon.transform.position, transform.rotation) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
    }
}
