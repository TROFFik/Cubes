using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    private bool ready = true;

    public bool Ready
    {
        get { return ready; }
        set { ready = value; }
    }
    public void ReturnToPool()
    {
        transform.localPosition = Vector3.zero;
        gameObject.SetActive(false);
        ready = true;
    }
}
