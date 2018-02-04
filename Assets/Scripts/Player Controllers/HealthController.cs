using UnityEngine;

public class HealthController : MonoBehaviour {

    [SerializeField] private FloatVariable playerHealth;
    [SerializeField] private FloatReference meteorDamageSmall;


    private void Start() {
        playerHealth.Value = 1f;
    }

    private void OnTriggerEnter2D(Collider2D coll) {
        if (coll.CompareTag("Meteor")) {
            playerHealth.Value -= meteorDamageSmall.Value;
            coll.GetComponent<ObjectDestroyController>().Destroy();
        }

        if (playerHealth.Value <= 0f) {
            Debug.Log("You Died!");
            Destroy(gameObject);
        }
    }

}
