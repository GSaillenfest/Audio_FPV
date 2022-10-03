using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Door : MonoBehaviour, IUsable
{

    [SerializeField] float animDuration;
    [SerializeField] Transform body;
    [SerializeField] AudioMixer audioMixer;
    float animTime;
    DoorState state;
    float closedDoorCutOff = 500f;
    float openedDoorCutoff = 5000f;


    // Start is called before the first frame update
    void Start()
    {
        state = DoorState.CLOSED;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == DoorState.OPENING)
        {

            if (animTime <= 1)
            {
                body.localPosition = Vector3.Lerp(Vector3.zero, Vector3.up, animTime);
                audioMixer.SetFloat("LowpassCutOff", Mathf.Lerp(closedDoorCutOff, openedDoorCutoff, animTime));
                animTime += Time.deltaTime/animDuration;
            }
            else
            {
                state = DoorState.OPENED;
                animTime = 0;
            }
        }
        else if (state == DoorState.CLOSING)
        {
            if (animTime <= 1)
            {
                body.localPosition = Vector3.Lerp(Vector3.up, Vector3.zero, animTime);
                audioMixer.SetFloat("LowpassCutOff", Mathf.Lerp(openedDoorCutoff, closedDoorCutOff, animTime));
                animTime += Time.deltaTime/animDuration;
            }
            else
            {
                state = DoorState.CLOSED;
                animTime = 0;
            }
        }
    }

    public void Use()
    {
        if (state == DoorState.CLOSED) state = DoorState.OPENING;
        else if (state == DoorState.OPENED) state = DoorState.CLOSING;
    }
}

public enum DoorState
{
    CLOSED,
    CLOSING,
    OPENED,
    OPENING
}
