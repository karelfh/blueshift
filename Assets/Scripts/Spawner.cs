using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ObjectPooler))]
public class Spawner : MonoBehaviour {

    [SerializeField] private float spawnValue;
    [SerializeField] private float spawnTime;

    private ObjectPooler objectPooler;
    
    private void Start() {
        objectPooler = GetComponent<ObjectPooler>();

        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    private void Spawn() {
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnValue, spawnValue),
                                            transform.position.y,
                                            transform.position.z);

        GameObject obj = objectPooler.GetPooledObject();

        if (obj == null) return;

        obj.transform.position = spawnPosition;
        obj.transform.rotation = transform.rotation;
        obj.SetActive(true);
    }

    // Show spawner in the scene
    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(10, 1, 1));
    }

}
