using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PoolMamager))]
public class MovmentCore : MonoBehaviour
{
    [SerializeField] protected float variableAffectingMovement;
    [SerializeField] protected Transform targetPoint;
    [SerializeField] protected Transform instPoint;
    [SerializeField] protected float instatiateTime;
    [SerializeField] protected Vector3 targetPos;
    [SerializeField] protected bool createObjects = true;
    protected List<GameObject> moveObjects = new List<GameObject>();
    protected PoolMamager pool;

    protected float distance;
    protected Coroutine coroutineTimer = null;

    private bool gameStart = false;

    public float Value
    {
        get
        {
           return variableAffectingMovement;
        }

        set
        {
            variableAffectingMovement = value;
        }
    }

    public Vector3 TargetPosValue
    {
        get
        {
            return targetPos;
        }

        set
        {
            targetPos = value;
            targetPoint.position = targetPos;
        }
    }
    public bool ChangeCreate
    {
        get
        {
            return createObjects;
        }
        set
        {
            createObjects = value;
            if (createObjects)
            {
                coroutineTimer = StartCoroutine(Timer());
            }
        }
    }
    protected void OnValidate()
    {
        if (createObjects && gameStart && coroutineTimer == null)
        {
            coroutineTimer = StartCoroutine(Timer());
        }
        if (targetPos != targetPoint.position)
        {
            targetPoint.position = targetPos;
        }
    }

    private void Awake()
    {
        gameStart = true;
    }

    protected IEnumerator Timer()
    {
        while (createObjects)
        {
            GameObject TempObject;
            TempObject = pool.GetPoolObject();
            if (TempObject != null)
            {
                AddObject(TempObject);
            }
            yield return new WaitForSeconds(instatiateTime);
        }

        coroutineTimer = null;
    }

    protected virtual void AddObject(GameObject TempObject)
    {
        moveObjects.Add(TempObject);
        TempObject.SetActive(true);
        TempObject.transform.position = instPoint.position;
    }
}
