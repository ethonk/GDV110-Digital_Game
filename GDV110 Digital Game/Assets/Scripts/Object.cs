﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public enum ObjectWeight {Light, Heavy};

    [Header("Object Settings")] 
    public ObjectWeight objectWeight;

    [Header("Timestop Related")]
    public float timestop_duration = 3.0f;

    [Header("Sound")]
    public AudioClip snd_timestop_resume;

    [Header("Starting Pos")]
    public Vector2 startPosition;
    
    void Start()
    {
        startPosition = transform.position;
    }

    public void ApplyTimestop()
    {
        StartCoroutine(TimeStopCoroutine());

        IEnumerator TimeStopCoroutine()
        {   
            GetComponent<Rigidbody2D>().gravityScale = 0;

            yield return new WaitForSeconds(timestop_duration);
            
            GetComponent<AudioSource>().PlayOneShot(snd_timestop_resume);
            GetComponent<Rigidbody2D>().AddForce(-transform.up);
            GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    } 
}
