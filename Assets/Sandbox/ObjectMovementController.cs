using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectDestroyController))]
public class ObjectMovementController : MonoBehaviour {

    [SerializeField] private float movementSpeed;

    private Vector2 movement;


    private void Update() {
        Move();
    }

    private void Move() {
        movement.Set(0, -1);
        movement = movement.normalized * movementSpeed * Time.deltaTime;

        transform.Translate(movement);
    }

}
