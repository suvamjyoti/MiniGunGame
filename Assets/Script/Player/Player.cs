using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(PlayerController))]
public class Player : MonoBehaviour
{

    [SerializeField] private float MovementSpeed;
    private PlayerController playerController;

    Camera viewCamera;

    
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        viewCamera = Camera.main;
    }


    void Update()
    {
        Movement();
        RotateTowardsMouse();
    }


    private void Movement()
    {
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 velocity = moveInput.normalized * MovementSpeed;

        playerController.Move(velocity);
    }


    private void RotateTowardsMouse()
    {
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;

        if (groundPlane.Raycast(ray, out rayDistance))
        {
            Vector3 point = ray.GetPoint(rayDistance);
            playerController.LookAt(point);
            //Debug.DrawLine(ray.origin,point,Color.red);
        }
    }

}
