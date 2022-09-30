using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour, IUsable
{

    public AudioSource sourceAudio;
    public Animator animator;

    bool sourceOn = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (sourceOn)
        {
            sourceAudio.enabled = true;
        }
        else
        {
            sourceAudio.enabled = false;
        }
        animator.SetBool("sourceOn", sourceOn);
    }

    public void Use()
    {
        sourceOn = !sourceOn;
    }
}
