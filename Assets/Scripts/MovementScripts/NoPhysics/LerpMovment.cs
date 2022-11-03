using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpMovment : MovmentCore
{
    private void Start()
    {
        pool = GetComponent<PoolMamager>();
        coroutineTimer = StartCoroutine(Timer());
    }
    private void FixedUpdate()
    {
        for (int i = 0; i < moveObjects.Count; i++)
        {
            moveObjects[i].transform.position = Vector3.Lerp(moveObjects[i].transform.position, targetPoint.position, variableAffectingMovement);
            if (Vector3.Distance(moveObjects[i].transform.position, targetPoint.position) <= 1f)
            {
                moveObjects[i].GetComponent<PoolObject>().ReturnToPool();
                i--;
            }
        }
    }

}
