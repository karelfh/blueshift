using UnityEngine;

public class MovementController : MonoBehaviour {

    [Header("Gameplay Settings")]
    [Tooltip("How fast can player move.")]
    [SerializeField] private float movementSpeed;

    [Header("Boundary Settings")]
    [Tooltip("How far forward can player move.")]
    [SerializeField] private float forwardDistance;
    [Range(0, 1)]
    [Tooltip("Padding on the edge of the screen on both sides.")]
    [SerializeField] private float padding;

    private Vector2 movement;
    private float minX, maxX, distanceFromCam;


    private void Start() {
        distanceFromCam = transform.position.z - Camera.main.transform.position.z;
    }

    private void Update() {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Move(horizontal, vertical);
    }

    private void Move(float horizontalAxis, float verticalAxis) {
        GetEdges();

        movement.Set(horizontalAxis, verticalAxis);
        movement = movement.normalized * movementSpeed * Time.deltaTime;

        transform.Translate(movement);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX),
                                         Mathf.Clamp(transform.position.y, 0f, forwardDistance),
                                         transform.position.z); 
    }

    private void GetEdges() {
        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, distanceFromCam));
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0f, distanceFromCam));

        minX = leftEdge.x + padding;
        maxX = rightEdge.x - padding;
    }

}
