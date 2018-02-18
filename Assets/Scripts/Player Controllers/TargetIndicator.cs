using UnityEngine;

public class TargetIndicator : MonoBehaviour {

    private Transform target;


    private void Update() {
        target = GameObject.FindGameObjectWithTag("Star").transform;

        Vector3 dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg; 

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

}
