using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{

    [SerializeField] Vector2 mouseSensitivity;
    [SerializeField] Vector2 padSensitivity;
    [SerializeField] Vector2 mouseYLimit;
    [SerializeField] Transform cameraPlayer;

    Vector2 position;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 MousePosition = new Vector2(Input.GetAxis("Mouse X") * mouseSensitivity.x, Input.GetAxis("Mouse Y") * mouseSensitivity.y) * Time.deltaTime;
        Vector2 PadPosition = new Vector2(Input.GetAxis("RightHorizontal") * padSensitivity.x, Input.GetAxis("RightVertical") * padSensitivity.y) * Time.deltaTime;

        position += MousePosition + PadPosition;

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, position.x, transform.eulerAngles.z);
        cameraPlayer.eulerAngles = new Vector3(Mathf.Clamp(position.y, mouseYLimit.x, mouseYLimit.y), cameraPlayer.eulerAngles.y, cameraPlayer.eulerAngles.z);
    }
}
