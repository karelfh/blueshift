using UnityEngine;

public class ObjectDestroyController : MonoBehaviour {


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Destroyer")) {
            Destroy();
        }
    }

    public void Destroy() {
        gameObject.SetActive(false);
    }

}
