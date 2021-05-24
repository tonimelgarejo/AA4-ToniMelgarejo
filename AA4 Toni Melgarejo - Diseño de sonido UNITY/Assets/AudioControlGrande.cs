using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControlGrande : MonoBehaviour
{
    AudioSource[] Sources;
    Rigidbody rb;

    float speed = 0.0f;
    private bool isPlaying = false;
    
    // Start is called before the first frame update
    void Start()
    {
        Sources = GetComponents<AudioSource>();
        rb = GetComponent<Rigidbody>();
        Sources[0].Play();
    }

    // Update is called once per frame
    void Update()
    {
        speed = rb.velocity.magnitude;
        
        if (speed > 0.1f && !isPlaying) {
            isPlaying = true;
            Sources[1].Play();
        } else if (speed < 0.1f) {
            isPlaying = false;
            Sources[1].Stop();
        }

        Sources[1].pitch = speed / 2.0f;
    }
    
    // método llamado por Unity cuando chocamos con algo ...
    void OnCollisionEnter(Collision collision)
    {
        Sources[0].Play();
        
    }
}