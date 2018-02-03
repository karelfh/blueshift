using UnityEngine;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour {

    [SerializeField] private GameObject[] objectsToPool;
    [SerializeField] private int pooledAmount;
    [SerializeField] private bool willGrow;

    public List<GameObject> pooledObjects;


    private void Start() {
        pooledObjects = new List<GameObject>();

        for (int i = 0; i < pooledAmount; i++) {
            for (int j = 0; j < objectsToPool.Length; j++) {
                GameObject obj = Instantiate(objectsToPool[j]) as GameObject;
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }
    }

    public GameObject GetPooledObject() {
        for (int i = 0; i < pooledObjects.Count; i++) {
            if (!pooledObjects[i].activeInHierarchy) {
                return pooledObjects[i];
            }
        }

        if (willGrow) {
            int index = Random.Range(0, objectsToPool.Length);

            GameObject obj = Instantiate(objectsToPool[index]);
            pooledObjects.Add(obj);
            return obj;
        }

        return null;
    }

}
