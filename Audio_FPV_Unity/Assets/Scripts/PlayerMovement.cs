using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float playerSpeed;
    [SerializeField] CharacterController characterController;
    [SerializeField] AudioSource footSteps;

    float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetButton("Sprint")) speed = playerSpeed * 2;
        else speed = playerSpeed;
        
            Vector3 direction = speed * Time.deltaTime * (transform.right * horizontalInput + transform.forward * verticalInput).normalized;

        characterController.Move(direction);
        footSteps.pitch = characterController.velocity.magnitude / playerSpeed;
    }
}
