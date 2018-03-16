using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour {

    [SerializeField] private FloatVariable playerHealth;
    [SerializeField] private FloatReference meteorDamageSmall;
    [SerializeField] private Sprite[] damageSprites;

    [SerializeField] private UnityEvent deathEvent;
    [SerializeField] private UnityEvent hitEvent;

    private int hitCount;
    private bool restarted;


    private void Start() {
        Time.timeScale = 1f;
        playerHealth.Value = 1f;
        hitCount = 0;
    }

    private void OnTriggerEnter2D(Collider2D coll) {
        if (coll.CompareTag("Meteor")) {          
            hitCount++;

            playerHealth.Value -= meteorDamageSmall.Value;
            coll.GetComponent<ObjectDestroyController>().Destroy();

            if (playerHealth.Value <= 0f) {
                deathEvent.Invoke();
                Time.timeScale = 0f;
            } else {
                hitEvent.Invoke();
                LoadDamageSprite();
            }
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
