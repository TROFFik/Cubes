using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothDampMovment : MovmentCore
{
    [SerializeField] private Vector3 velocity = Vector3.zero;
    private void Start()
    {
        pool = GetComponent<PoolMamager>();
        coroutineTimer = StartCoroutine(Timer());
    }
    private void Update()
    {
        for (int i = 0; i < moveObjects.Count; i++)
        {
            moveObjects[i].transform.position = Vector3.SmoothDamp(moveObjects[i].transform.position, targetPoint.position, ref velocity, variableAffectingMovement);

            if (Vector3.Distance(moveObjects[i].transform.position, targetPoint.position) <= 1f)
            {
                moveObjects[i].GetComponent<PoolObject>().ReturnToPool();
                moveObjects.Remove(moveObjects[i]);
                i--;
            }
        }
    }
}
