using UnityEngine;

public class TargetIndicator : MonoBehaviour {

    [SerializeField] private FloatReference hideDistance;
    [SerializeField] private FloatReference showDistance;

    private Transform target;


    private void Update() {
        target = GameObject.FindGameObjectWithTag("Star").transform;

        Vector3 directiuon = target.position - transform.position;
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance < hideDistance && distance < showDistance) {
            ToggleArrow(false);
        } else {
            ToggleArrow(true);

            float angle = Mathf.Atan2(directiuon.y, directiuon.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }     
    }

    private void ToggleArrow(bool value) {
        foreach (Transform child in transform) {
            child.gameObject.SetActive(value);
        }
    }

}
