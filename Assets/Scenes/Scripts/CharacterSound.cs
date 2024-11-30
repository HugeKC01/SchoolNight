using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip walkingSound;
    public float walkingPitch = 0.5f;
    public float sprintingPitch = 1.0f;
    private CharacterController characterController;
    private bool isSprinting;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.clip = walkingSound;
        audioSource.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the character is sprinting
        isSprinting = Input.GetKey(KeyCode.LeftShift);

        if (characterController != null && characterController.velocity.magnitude > 0.1f)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }

            audioSource.pitch = isSprinting ? sprintingPitch : walkingPitch;
        }
        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Pause();
            }
        }
    }
}