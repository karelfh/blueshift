using UnityEngine;

[RequireComponent(typeof(ObjectDestroyController))]
public class ObjectMovementController : MonoBehaviour {

    [SerializeField] private FloatReferece movementSpeed;

    private Vector2 movement;


    private void Update() {
        Move();
    }

    private void Move() {
        movement.Set(0, -1);
        movement = movement.normalized * movementSpeed.Value * Time.deltaTime;

        transform.Translate(movement);
    }

}
