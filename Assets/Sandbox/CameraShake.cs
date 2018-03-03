using UnityEngine;
using System.Collections;

public class CameraShake : SingletonMonoBehaviour<CameraShake> {

    [SerializeField] private FloatReference shakeIntesity;
    [SerializeField] private FloatReference shakeDuration;

    [System.NonSerialized] public bool isShaking = false;

    private Vector3 originalCamPos;
    private Quaternion originalCamRot;


    private void Update() {
        if (isShaking) {
            StartCoroutine(Shaking());
        }
    }

    public void EnableShake() {
        originalCamPos = Camera.main.transform.localPosition;
        originalCamRot = Camera.main.transform.localRotation;

        isShaking = true;
    }

    private IEnumerator Shaking() {
        float shake = Random.Range(-shakeIntesity, shakeIntesity);
        transform.localRotation = Quaternion.Euler(0f, 0f, shake);

        yield return WaitFor(shakeDuration);

        Disable();
    }

    private void Disable() {
        isShaking = false;

        transform.localPosition = originalCamPos;
        transform.localRotation = originalCamRot;
    }

    private IEnumerator WaitFor(float seconds) {
        float end = Time.realtimeSinceStartup + seconds;

        while (Time.realtimeSinceStartup < end) {
            yield return null;
        }
    }

}
