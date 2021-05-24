using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelota1AudioCOntroller : MonoBehaviour
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
            Sources[2].Play();
        } else if (speed < 0.1f) {
            isPlaying = false;
            Sources[2].Stop();
        }

        Sources[2].pitch = speed / 4.0f;
    }
    
    // método llamado por Unity cuando chocamos con algo ...
    void OnCollisionEnter(Collision collision)
    {
        Sources[1].Play();
        
    }
}