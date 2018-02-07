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
    private float minX, maxX, distanceFromCam;


    private void Start() {
        distanceFromCam = transform.position.z - Camera.main.transform.position.z;
    }

    private void Update() {
        float pointer_x = Input.GetAxis("Mouse X");
        float pointer_y = Input.GetAxis("Mouse Y");

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (Input.touchCount > 0) {
            pointer_x = Mathf.Clamp(Input.touches[0].deltaPosition.x, -1f, 1f);
            pointer_y = Mathf.Clamp(Input.touches[0].deltaPosition.y, -1f, 1f);
        }

        Move(pointer_x, pointer_y);
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

    private void GetEdges() {
        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, distanceFromCam));
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0f, distanceFromCam));

        minX = leftEdge.x + padding.Value;
        maxX = rightEdge.x - padding.Value;
    }

}
