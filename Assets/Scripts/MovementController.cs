using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {

    [SerializeField] private float movementSpeed;

    private Vector2 movement;


    private void Update() {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Move(horizontal, vertical);
    }

    private void Move(float horizontalAxis, float verticalAxis) {
        movement.Set(horizontalAxis, verticalAxis);
        movement = movement.normalized * movementSpeed * Time.deltaTime;

        transform.Translate(movement);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2f, 2f),
                                         Mathf.Clamp(transform.position.y, 0f, 2f),
                                         transform.position.z); 
    }

}
