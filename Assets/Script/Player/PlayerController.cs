using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidBody;
    private Vector3 velocity;


    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.position + velocity * Time.deltaTime);
    }

    
    public void LookAt(Vector3 _point)
    {
        //adjust according to height
        Vector3 correctedPoint = new Vector3(_point.x, rigidBody.position.y, _point.z);
        transform.LookAt(correctedPoint);
    }

    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }



}
