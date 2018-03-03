using UnityEngine;

public class MovementController : MonoBehaviour {

    [Header("Gameplay Settings")]
    [Tooltip("How fast can player move.")]
    [SerializeField] private FloatReference movementSpeed;

    [Header("Boundary Settings")]
    [Tooltip("How far forward can player move.")]
    [SerializeField] private FloatReference forwardDistance;

    [Tooltip("Padding on the edge of the screen on both sides.")]
    [SerializeField] private FloatReference padding;

    private Vector2 movement;
    private float minX, maxX, distanceFromCam, screenCenterX;


    private void Start() {
        distanceFromCam = transform.position.z - Camera.main.transform.position.z;
        screenCenterX = Screen.width * 0.5f;
    }

    private void Update() {
        GetEdges();

        Move(GetHorizontalTouch(), 0);
    }

    private void Move(float horizontalAxis, float verticalAxis) {
        GetEdges();

        movement.Set(horizontalAxis, verticalAxis);
        movement = movement.normalized * movementSpeed.Value * Time.deltaTime;

        transform.Translate(movement);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX),
                                         Mathf.Clamp(transform.position.y, 0f, forwardDistance.Value),
                                         transform.position.z);
    }

    private float GetHorizontalTouch() {
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);

            if (touch.phase != TouchPhase.Ended) {
                if (touch.position.x > screenCenterX) {
                    return 1f;
                } else if (touch.position.x < screenCenterX) {
                    return -1f;
                }
            }
        }

        return 0f;
    }

    private void GetEdges() {
        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, distanceFromCam));
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0f, distanceFromCam));

        minX = leftEdge.x + padding.Value;
        maxX = rightEdge.x - padding.Value;
    }
}