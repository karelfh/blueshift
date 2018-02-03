using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyController : MonoBehaviour {


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Destroyer")) {
            Destroy();
        }
    }

    private void Destroy() {
        gameObject.SetActive(false);
    }

}
