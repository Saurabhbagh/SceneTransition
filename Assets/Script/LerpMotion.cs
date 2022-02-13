using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpMotion : MonoBehaviour
{

    // Transforms to act as start and end markers for the journey.
    public Vector3 startMarker;
    public Vector3 endMarker;

    // Movement speed in units per second.
    public float speed = 1.0F;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    void Start()
    {
        // Keep a note of the time the movement started.
        startTime = Time.time;
        startMarker = gameObject.transform.position;
        endMarker = new Vector3(0f, 0f, 0f);

        // Calculate the journey length.
        journeyLength = Vector3.Distance(startMarker, endMarker);
    }

    // Move to the target end position.
    void Update()
    {
        
        if(journeyLength>0.5f)
        {   // Distance moved equals elapsed time times speed..
            float distCovered = (Time.time - startTime) * speed;

            // Fraction of journey completed equals current distance divided by total distance.
            float fractionOfJourney = distCovered / journeyLength;

            // Set our position as a fraction of the distance between the markers.
            transform.position = Vector3.Lerp(startMarker, endMarker, fractionOfJourney);

        }
        
    }
}
