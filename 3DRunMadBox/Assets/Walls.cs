using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    // Start is called before the first frame update
    bool fall = false;
    bool rise = false;
    float time = 0;

    [SerializeField, Range(0.0f, 10.0f)]
    private float timer = 0.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fall)
        {
            transform.position -= Vector3.up * 5 * Time.deltaTime;
        }

        if (rise)
        {
            transform.position += Vector3.up * 5 * Time.deltaTime;

        }
        // transform.position -= Vector3.up *5* Time.deltaTime;
    }

    void OnTriggerStay(Collider other)
    {
        time = time + Time.deltaTime;
        if(time >= timer)
        {
            if (other.name == "Roof")
            {
                transform.position -= Vector3.up * 5 * Time.deltaTime;
                fall = true;
                rise = false;
            }

            if (other.name == "Cube (2)")
            {
                rise = true;
                fall = false;
                transform.position += Vector3.up * 5 * Time.deltaTime;
            }
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        
    }
}
