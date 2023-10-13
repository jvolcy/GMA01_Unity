using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleCtrl : MonoBehaviour
{
    //create a front-panel field to input the max velocity
    [SerializeField]
    float maxVelocity;

    // Start is called before the first frame update
    void Start()
    {
        //get a reference to the GOs Ridigbody component
        Rigidbody2D rb;
        rb = GetComponent<Rigidbody2D>();

        //set the initial x and y velocities
        rb.velocity = new Vector2(Random.Range(-maxVelocity, maxVelocity), Random.Range(-maxVelocity, maxVelocity));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Debug.Log(Input.mousePosition);
            if (Vector2.Distance(mousePos, transform.position) < 16f)   //the radius of the orbs is 16
            {
                //get a reference to the GOs AudioSource component
                AudioSource audioSource;
                audioSource = GetComponent<AudioSource>();

                //play the clip
                audioSource.Play();

                //destroy the GO
                Destroy(gameObject, 0.1f); //delay 0.1 sec to allow "pop" sound to play
            }
        }
    }
}
