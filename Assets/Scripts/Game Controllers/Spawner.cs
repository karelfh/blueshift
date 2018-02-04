using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ObjectPooler))]
public class Spawner : MonoBehaviour {
    
    [SerializeField] private FloatReference spawnValue;
    [SerializeField] private FloatReference spawnDelay;   

    private ObjectPooler objectPooler;


    private void Start() {
        objectPooler = GetComponent<ObjectPooler>();

        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn() {
        while (true) {
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValue, spawnValue),
                                                transform.position.y,
                                                transform.position.z);

            GameObject obj = objectPooler.GetPooledObject();

            if (obj == null) {
                Debug.LogError("There are no objects to spawn! Add objects to object pooler component.");
                StopCoroutine(Spawn());
            }
        
            obj.transform.position = spawnPosition;
            obj.transform.rotation = transform.rotation;
            obj.SetActive(true);

            yield return new WaitForSeconds(spawnDelay);
        }
    }

    // Show spawner in the scene
    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(10, 1, 1));
    }

}
