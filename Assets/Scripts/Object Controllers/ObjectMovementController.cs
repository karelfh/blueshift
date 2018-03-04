using UnityEngine;

[RequireComponent(typeof(ObjectDestroyController))]
public class ObjectMovementController : MonoBehaviour {

    [SerializeField] private FloatReference movementSpeed;
    [Space]
    [SerializeField] private bool canRotate;
    [SerializeField] private Transform body;
    [SerializeField] private FloatReference minRotationSpeed;
    [SerializeField] private FloatReference maxRotationSpeed;

    private Vector2 movement;


    private void Update() {
        Move();

        if (canRotate) {
            Rotate();
        }
    }

    private void Move() {
        movement.Set(0, -1);
        movement = movement.normalized * movementSpeed.Value * Time.deltaTime;

        transform.Translate(movement);
    }

    private void Rotate() {
        float rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);

        body.transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime, Space.World);
    }

}
