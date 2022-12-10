using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
   ObjectPooler objectPooler;
    void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }

    
    void FixedUpdate()
    {
        QueueErrorException();
    }

    public void QueueErrorException()
    {
        try
        {
            GameObject obj = objectPooler.GetPooledObject();
            obj.transform.position = new Vector3(Random.Range(0,3),this.transform.position.y,Random.Range(1,3));
        }
        catch (System.Exception)
        {
            Debug.Log("Exception");
        }

    }
    
}
