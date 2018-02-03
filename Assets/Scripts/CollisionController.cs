using UnityEngine;

public class CollisionController : MonoBehaviour {


    private void OnTriggerEnter2D(Collider2D coll) {
        if (coll.CompareTag("Meteor")) {
            Debug.Log("Hit by: " + coll.gameObject.name);

            // Destroy meteor, get damage, die if health <= 0
            coll.GetComponent<ObjectDestroyController>().Destroy();
        }

        if (coll.CompareTag("Star")) {
            Debug.Log("Collected: " + coll.gameObject.name);

            // Destroy star, get score, reload 1 missile
            coll.GetComponent<ObjectDestroyController>().Destroy();
        }
    }

}
