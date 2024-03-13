using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : Villager
{
    public GameObject knifePrefab;
    public Transform spawnPoint;
    public Transform spawnPoint2;

    float dashAmount = 3;


    public override ChestType CanOpen()
    {
        return ChestType.Thief;
    }

    protected override void Attack()
    {
        Instantiate(knifePrefab, spawnPoint.position, spawnPoint.rotation);
        Instantiate(knifePrefab, spawnPoint2.position, spawnPoint2.rotation);

        Vector2 localDestination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 localMovement = localDestination - (Vector2)transform.position;

        rb.position = rb.position + localMovement.normalized * dashAmount;

        destination = rb.position;


        //rb.position = rb.position + movement.normalized * dashAmount;
        //rb.MovePosition(rb.position + finalDirection.normalized * dashAmount);

        base.Attack();
        

    }
}
