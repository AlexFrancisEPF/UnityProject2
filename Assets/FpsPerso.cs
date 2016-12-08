using System;
using UnityEngine;

public class FpsPerso : MonoBehaviour
{
    public float mouseSensitivity = 100.0f;
    public float clampAngle = 80.0f;

    private float rotY = 0.0f; // rotation around the up/y axis
    private float rotX = 0.0f; // rotation around the right/x axis

    private CharacterController Cc;
    public float Gravite = 0.1f;
    public float Speed = 20;
    public AudioClip SoundSplash;
    public AudioClip SoundUnderWater;

    void OnEnable()
    {
        if (GetComponent<AudioSource>().isPlaying == false) GetComponent<AudioSource>().PlayOneShot(SoundSplash);
    }

    void Start()
    {
        Cc = GetComponent<CharacterController>();
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
    }

    void Update()
    {
        if (GetComponent<AudioSource>().isPlaying == false) GetComponent<AudioSource>().PlayOneShot(SoundUnderWater);

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");

        rotY += mouseX * mouseSensitivity * Time.deltaTime;
        rotX += mouseY * mouseSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;

        Cc.Move(Vector3.up * -Gravite);

        if(Input.GetKey(KeyCode.Z))
        {
            Cc.Move(transform.TransformDirection(Vector3.forward)*Speed *Time.deltaTime);
        }
    }
}