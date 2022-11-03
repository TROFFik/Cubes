using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolMamager : MonoBehaviour
{
    [SerializeField] private PoolObject poolObject;
    [SerializeField] private int minObjectCount;
    [SerializeField] private int maxObjectCount;

    private int currentObjectCount;
    private List<PoolObject> listObjects = new List<PoolObject>();

    private void Start()
    {
        currentObjectCount = minObjectCount;
        CreatePool();
    }
    private void CreatePool()
    {
        listObjects = new List<PoolObject>(minObjectCount);

        for (int i = 0; i < minObjectCount; i++)
        {
            CreateObject();
        }
    }

    private GameObject CreateObject()
    {
        GameObject TempObject;  
        TempObject = Instantiate(poolObject.gameObject, transform);
        listObjects.Add(TempObject.GetComponent<PoolObject>());
        TempObject.SetActive(false);
        return TempObject;
    }
    public GameObject GetPoolObject()
    {
        foreach (var item in listObjects)
        {
            if (item.Ready)
            {
                item.Ready = false;
                return item.gameObject;
            }
        }
        if (currentObjectCount < maxObjectCount)
        {
            currentObjectCount++;
            return CreateObject();
        }
        
        return null;
    }
}
