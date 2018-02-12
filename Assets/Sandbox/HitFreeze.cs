using UnityEngine;
using System.Collections;

public class HitFreeze : MonoBehaviour {

    [SerializeField] private float freezeDuration;

    private bool isFrozen = false;
    private float pendingFreezeDuration = 0f;


    public void Freeze() {
        pendingFreezeDuration = freezeDuration;

        if (pendingFreezeDuration > 0 && !isFrozen) {
            StartCoroutine(DoFreeze());
        }
    }

    private IEnumerator DoFreeze() {
        Debug.Log("Started");
        isFrozen = true;
        Time.timeScale = 0f;

        yield return new WaitForSecondsRealtime(freezeDuration);

        Debug.Log("Ended");
        Time.timeScale = 1f;
        pendingFreezeDuration = 0f;
        isFrozen = false;
    }

}
