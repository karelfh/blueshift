using UnityEngine;

public class CollisionController : MonoBehaviour {

    [Header("Damage Settings")]
    [SerializeField] private FloatVariable playerHealth;
    [SerializeField] private FloatReferece meteorDamageSmall;

    [Header("Score Settings")]
    [SerializeField] private IntVariable playerScore;
    [SerializeField] private IntReference starScoreValue;


    private void OnTriggerEnter2D(Collider2D coll) {
        if (coll.CompareTag("Meteor")) {
            // Destroy meteor, get damage
            playerHealth.value -= meteorDamageSmall.Value;
            coll.GetComponent<ObjectDestroyController>().Destroy();
        }

        if (playerHealth.value <= 0f) {
            Debug.Log("You Died!");
            Destroy(gameObject);
        }

        if (coll.CompareTag("Star")) {
            // Destroy star, get score, reload 1 missile
            playerScore.value += starScoreValue.Value;
            coll.GetComponent<ObjectDestroyController>().Destroy();
        }
    }

}
