using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;

    public float speed, horizontalmultiplier, jumpforce;

    public float horizontalinput;

    public LayerMask groundlayermask;

    public Vector3 smallsize = new Vector3(0.5f, 0.5f, 0.5f);
    
    public Vector3 normalsize = new Vector3(1.25f, 1.25f, 1.25f);
    
    public bool CanScale;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalinput = Input.GetAxisRaw("Horizontal");
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            StartCoroutine(changeSize());
        }

        if(CanScale)
        {
            SmallBall();
        }
        else
        {
            NormalBall();
        }
    }

    void FixedUpdate()
    {
        Vector3 forwardmove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalmove = transform.right * horizontalinput * Time.fixedDeltaTime * horizontalmultiplier;
        rb.MovePosition(rb.position + forwardmove + horizontalmove);
    }

    void Jump()
    {
        float height = GetComponent<Collider>().bounds.size.y;
        bool isgrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundlayermask);
        if(isgrounded)
        {
            rb.AddForce(Vector3.up * jumpforce);
        }
        
    }

    IEnumerator changeSize()
    {
        CanScale = true;
        yield return new WaitForSeconds(1.25f);
        CanScale = false;
    }

    void SmallBall()
    {
        transform.localScale = smallsize; 
    }

    void NormalBall()
    {
        transform.localScale = normalsize;
    }
}
