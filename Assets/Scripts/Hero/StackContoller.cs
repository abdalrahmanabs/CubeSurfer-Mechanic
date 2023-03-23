using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StackContoller : MonoBehaviour
{
    public List<GameObject> cubes = new List<GameObject>();
    GameObject LastCube;
    Rigidbody rb;
    [SerializeField] private GameObject RemovedCubes;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        UpdateLastCubeObject();
    }
    private void UpdateLastCubeObject()
    {
        LastCube = cubes[cubes.Count - 1];
        if(cubes.Count>0)
         rb.useGravity=true;
            
    }
    public void IncreaseCubeStack(GameObject collectedCube)
    {
        transform.position = new Vector3(transform.position.x, (transform.position.y) + 1, transform.position.z);
        collectedCube.transform.position = new Vector3(LastCube.transform.position.x, LastCube.transform.position.y - 1f, LastCube.transform.position.z);
        collectedCube.transform.SetParent(transform);
        cubes.Add(collectedCube);
        UpdateLastCubeObject();
    }
    public void DecreaseCubeStack(GameObject Object)
    {
        int CubeIndex = cubes.IndexOf(Object);
        Object.transform.parent = null;
        cubes.Remove(Object);
        Object.transform.parent = RemovedCubes.transform;
        Object.GetComponent<CollectableCubeController>().enabled = false;
        UpdateLastCubeObject();
    }
}
