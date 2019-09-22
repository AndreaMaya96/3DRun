using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(player.GetComponent<PlayerMove>().FirstCamMove == true){
            if (Mathf.Approximately(transform.localRotation.eulerAngles.y, 270f))
            {
                transform.Rotate(0, 0, 0);
            }
            else
            {
                transform.Rotate(0, -30f * Time.deltaTime, 0);
            }
        }
    }
}
