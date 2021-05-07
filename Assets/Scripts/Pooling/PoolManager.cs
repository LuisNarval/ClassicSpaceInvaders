using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    
    public int startingObjects;
    public GameObject prefabObject;
    public List<GameObject> objectsSpawned;

    private GameObject instancedObject;

    void Start()
    {
        objectsSpawned = new List<GameObject>();
        if (startingObjects > 0)
            CreateInitialObjects();
    }


    
    public void DisableAllObjects()
    {
        for (int i = 0; i < objectsSpawned.Count; i++)
        {
            objectsSpawned[i].gameObject.SetActive(false);
        }
    }

    
    [ContextMenu("Create initial objects")]
    public virtual void CreateInitialObjects()
    {
        if (objectsSpawned == null)
            objectsSpawned = new List<GameObject>();
        for (int i = 0; i<startingObjects; i++)
        {
            CreateObject(false);
        }
    }

    public virtual GameObject CreateObject(bool enabledAtInstance = true)
    {
        GameObject instancedObject = null;

        if (prefabObject == null)
            Debug.LogError("Object not assigned for instance");
        else
        {
            instancedObject = (GameObject)Instantiate(prefabObject, Vector3.zero, Quaternion.identity);
            objectsSpawned.Add(instancedObject);

            if (!enabledAtInstance)
                instancedObject.SetActive(false);
        }

        

        return instancedObject;
    }

    public virtual GameObject AskForObject(Vector3 startingPos)
    {
        for (int i = 0; i< objectsSpawned.Count;i++)
        {
            if (!objectsSpawned[i].gameObject.activeInHierarchy)
            {
                objectsSpawned[i].gameObject.SetActive(true);
                objectsSpawned[i].transform.position = startingPos;
                return objectsSpawned[i].gameObject;
            }
        }

        instancedObject = CreateObject();
        instancedObject.transform.position = startingPos;
        return instancedObject;
        
        
    }


    
}
