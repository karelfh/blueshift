using UnityEngine;

public class PlayerFollow : MonoBehaviour {

    public float padding;

    private Vector3 pos;
    private float minX, maxX, distanceFromCam;

    private void Start() {
        distanceFromCam = transform.position.z - Camera.main.transform.position.z;
    }

    private void Update() {
        GetEdges();
        pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, 0, 10));

        transform.position = new Vector3(Mathf.Clamp(pos.x, minX, maxX), pos.y, pos.z);
    }

    private void GetEdges() {
        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, distanceFromCam));
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0f, distanceFromCam));

        minX = leftEdge.x + padding;
        maxX = rightEdge.x - padding;
    }
}
