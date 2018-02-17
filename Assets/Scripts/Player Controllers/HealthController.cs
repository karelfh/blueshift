using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class HealthController : MonoBehaviour {

    [SerializeField] private FloatVariable playerHealth;
    [SerializeField] private FloatReference meteorDamageSmall;
    [SerializeField] private Sprite[] damageSprites;

    [SerializeField] private UnityEvent deathEvent;
    [SerializeField] private UnityEvent hitEvent;

    private int hitCount;


    private void Start() {
        Time.timeScale = 1f;
        playerHealth.Value = 1f;
        hitCount = 0;
    }

    private void OnTriggerEnter2D(Collider2D coll) {
        if (coll.CompareTag("Meteor")) {
            hitEvent.Invoke();
            hitCount++;

            playerHealth.Value -= meteorDamageSmall.Value;
            coll.GetComponent<ObjectDestroyController>().Destroy();
        }

        if (playerHealth.Value <= 0f) {
            // Play destroy animation, destroy player, show score and stop time
            deathEvent.Invoke();

            Time.timeScale = 0f;
        } else {
            LoadDamageSprite();
        }
    }

    private void LoadDamageSprite() {
        int spriteIndex = hitCount - 1;

        if (damageSprites[spriteIndex]) {
            GameObject.Find("Player/Damage").GetComponent<SpriteRenderer>().sprite = damageSprites[spriteIndex];
        } else {
            Debug.LogError("Damage sprite is missing!");
        }
    }

}
