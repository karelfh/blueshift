using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class HealthController : MonoBehaviour {

    [SerializeField] private FloatVariable playerHealth;
    [SerializeField] private FloatReference meteorDamageSmall;
    [SerializeField] private UnityEvent deathEvent;


    private void Start() {
        Time.timeScale = 1f;
        playerHealth.Value = 1f;
    }

    private void OnTriggerEnter2D(Collider2D coll) {
        if (coll.CompareTag("Meteor")) {
            playerHealth.Value -= meteorDamageSmall.Value;
            coll.GetComponent<ObjectDestroyController>().Destroy();
        }

        if (playerHealth.Value <= 0f) {
            // Play destroy animation, destroy player, show score and stop time

            deathEvent.Invoke();
            Time.timeScale = 0f;
        }
    }

}
