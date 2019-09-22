using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform goal;
    NavMeshAgent agent;
    public bool dead = false;
    Animator anim;
    Rigidbody rb;
    Vector3 deadPos;
    public bool FirstCamMove;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        FirstCamMove = true;
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Ball")
        {
            dead = true;
            anim.SetBool("Dead", true);
            rb.isKinematic = true;
            deadPos = transform.position;
        }

        if (collision.gameObject.name == "Wall")
        {
            dead = true;
            anim.SetBool("Dead", true);
            rb.isKinematic = true;
            deadPos = transform.position;

        }
    }

    void Restart()
    {
        SceneManager.LoadScene(0);
    }
    // Update is called once per frame
    void Update()
    {
        if(dead == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                anim.SetBool("Run", true);

                agent.destination = goal.position;
            }
            if (Input.GetMouseButtonUp(0))
            {
                anim.SetBool("Run", false);

                agent.destination = agent.transform.position;
            }
        }
        else
        {
            transform.position = deadPos;
        }
     if(agent.transform.localPosition.x == goal.position.x)
        {
            Restart();
        }
    }
}
