using UnityEngine;
using System.Collections;

public class ParticleSpawner : MonoBehaviour {

    private ObjectPooler objectPooler;

    private Vector3 tmpContactPoint;
    private Vector3 tmpDirection;
    private GameObject tmpGamob;


    private void Awake() {
        objectPooler = GetComponent<ObjectPooler>();
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.tag != "Meteor") return;

        tmpDirection = (col.transform.position - transform.position);
        tmpContactPoint = transform.position + tmpDirection;
    }

    private IEnumerator Spawn() {      
        GameObject obj = objectPooler.GetPooledObject();

        if (obj == null) {
            Debug.LogError("There are no objects to spawn! Add objects to object pooler component.");
        }

        obj.transform.position = tmpContactPoint;
        obj.transform.rotation = transform.rotation;
        obj.SetActive(true);

        yield return new WaitForSeconds(1.1f);

        obj.SetActive(false);
    }

    public void SpawnParticles() {
        StartCoroutine(Spawn());
    }

}
