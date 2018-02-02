using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    [SerializeField] private float spawnValue;
    [SerializeField] private GameObject[] objects;


    private void Start() {
        Spawn();
    }

    private IEnumerator Spawn() {
        // Start Delay
        yield return new WaitForSeconds(1f);

        while (true) {
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValue, spawnValue),
                                                transform.position.y,
                                                transform.position.z);

            // Spawn

            // Delay after spawning one object
            yield return new WaitForSeconds(1f);
        }
    }

    // Show spawner in the scene - remove in final build
    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(10, 1, 1));
    }

}
