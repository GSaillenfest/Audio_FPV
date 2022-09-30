using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbulanceMovement : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] float maxDistance;
    [SerializeField] float minDistance;
    [SerializeField] Rigidbody rbdy;

    bool isFacingNorth = true;

    // Start is called before the first frame update
    void Start()
    {
        PushForward();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFacingNorth && transform.position.z > maxDistance)
        {
            UTurn();
        }
        else if (!isFacingNorth && transform.position.z < minDistance) UTurn();
    }

    void PushForward()
    {
        rbdy.velocity = transform.forward * speed;
    }

    void UTurn()
    {
        rbdy.velocity = Vector3.zero;
        transform.forward = -transform.forward;

        isFacingNorth = !isFacingNorth;

        PushForward();
    }


}
