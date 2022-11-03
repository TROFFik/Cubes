using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceMovment : MovmentCore
{
    private Vector3 direction;
    private void Start()
    {
        pool = GetComponent<PoolMamager>();
        coroutineTimer = StartCoroutine(Timer());
    }
    private void FixedUpdate()
    {
        for (int i = 0; i < moveObjects.Count; i++)
        {
            direction = targetPoint.position - moveObjects[i].transform.position;
            distance = direction.magnitude;
            moveObjects[i].GetComponent<Rigidbody>().AddForce(direction/distance * variableAffectingMovement);
            if (Vector3.Distance(moveObjects[i].transform.position, targetPoint.position) <= 1f)
            {
                moveObjects[i].GetComponent<PoolObject>().ReturnToPool();
                moveObjects.Remove(moveObjects[i]);
                i--;
            }
        }
    }
}
