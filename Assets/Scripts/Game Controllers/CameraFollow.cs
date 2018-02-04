using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField] private Transform target;

    [SerializeField] private float borderValue;
    [SerializeField] private float followSpeed;


    private void LateUpdate() {
        Follow();
    }

    private void Follow() {
        Vector3 targetPosition = new Vector3(Mathf.Clamp(target.position.x, -borderValue, borderValue),
                                             transform.position.y,
                                             transform.position.z);

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        transform.position = smoothedPosition;
    }
}
