using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] float maxDistance;
    [SerializeField] Image crossHair;

    IUsable target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FindTarget();
        UseTarget();
        ChangeCrossHairState();
    }

    void FindTarget()
    {
        RaycastHit hitObject;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        if (!Physics.Raycast(ray, out hitObject, maxDistance))
        {
            target = null;
        }
        else
        {
            target = hitObject.transform.gameObject.GetComponent<IUsable>();
            Debug.Log("ok");    
        }

    }

    void UseTarget()
    {
        if (target != null && Input.GetButtonDown("Use"))
        {
            target.Use();
        }
    }

    void ChangeCrossHairState()
    {
        if (target != null) crossHair.color = Color.red;
        else crossHair.color = Color.white;
    }
}
