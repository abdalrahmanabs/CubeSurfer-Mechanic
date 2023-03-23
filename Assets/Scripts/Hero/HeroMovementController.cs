using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HeroMovementController : MonoBehaviour
{
    [SerializeField] private float maxDisplacement = 0.2f; // maximum displacement of the object
    [SerializeField] private float maxPositionX = 2f; // maximum position of the object
    [SerializeField] private float speed=5;

    Rigidbody rb;

    void Awake()
    {
        rb=GetComponent<Rigidbody>();
    }
    private Vector2 _anchorPosition; // anchor position of the object
    private void Update()
    {
        var inputX = GetInput(); // get the user's input
        var displacementX = Mathf.Clamp(inputX * Time.deltaTime, -maxDisplacement, maxDisplacement); // calculate the displacement and clamp it
        var newPosition = transform.position + new Vector3(displacementX, 0, 0); // calculate the new position
        transform.position = new Vector3(Mathf.Clamp(newPosition.x, -maxPositionX, maxPositionX),transform.position.y, transform.position.z);  // clamp the position
        transform.position+=Vector3.forward*Time.deltaTime*speed;
    }
    private float GetInput()
    {
        var inputX = 0f;
        if (Input.GetMouseButtonDown(0)) 
        {
            _anchorPosition = Input.mousePosition; 
        }
        else if (Input.GetMouseButton(0)) 
        {
            inputX = (Input.mousePosition.x - _anchorPosition.x); 
            _anchorPosition = Input.mousePosition; 
        }
        return inputX; 
    }
}
