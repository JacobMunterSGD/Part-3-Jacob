using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Villager
{

    public GameObject arrowPrefab;
    public Transform spawnPoint;

    protected override void Attack()
    {
        destination = transform.position;
        Instantiate(arrowPrefab, spawnPoint.position, spawnPoint.rotation);
        base.Attack();
        
    }

}