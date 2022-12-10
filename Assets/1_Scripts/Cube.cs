using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Cube : MonoBehaviour
{
    ObjectPooler objectPooler;
    public float distanceBetweenCubeAndSphere;
    public GameObject finishPoint;
    void Start()
    {
        DOTween.SetTweensCapacity(1000000,1000000);
        objectPooler = ObjectPooler.Instance;
    }

    void Update()
    {
        DeactiveAndEnqueueCube();
    }

    public void DeactiveAndEnqueueCube()
    {
        
        float dist =Vector3.Distance(this.transform.position,finishPoint.transform.position);
        if (dist <= distanceBetweenCubeAndSphere)
        {
            this.gameObject.SetActive(false);
            objectPooler.objectPool.Enqueue(this.gameObject);
        }
    }
}
