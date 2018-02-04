using UnityEngine;

public class CollisionController : MonoBehaviour {

    [Header("Damage Settings")]
    [SerializeField] private FloatVariable playerHealth;
    [SerializeField] private FloatReference meteorDamageSmall;

    [Header("Score Settings")]
    [SerializeField] private FloatVariable playerScore;
    [SerializeField] private FloatReference starScoreValue;


    private void OnTriggerEnter2D(Collider2D coll) {
        if (coll.CompareTag("Meteor")) {
            // Destroy meteor, get damage
            playerHealth.Value -= meteorDamageSmall.Value;
            coll.GetComponent<ObjectDestroyController>().Destroy();
        }

        if (playerHealth.Value <= 0f) {
            Debug.Log("You Died!");
            Destroy(gameObject);
        }

        if (coll.CompareTag("Star")) {
            // Destroy star, get score, reload 1 missile
            playerScore.Value += starScoreValue.Value;
            coll.GetComponent<ObjectDestroyController>().Destroy();
        }
    }

}
