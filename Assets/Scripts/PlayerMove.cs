using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    bool running = false;
    public float leftBound, rightBound, topBound, bottomBound, moveSpeed;
    float moveX = 0f;
    float moveY = 0f;
    public Transform footprint, bullet, barrel;
    public Animator anim;
    float cooldown = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a") && footprint.position.x > leftBound)
        {
          running = true;
          transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * -1f, transform.localScale.y, 1f);
          moveX = -1f;
        }
        else if (Input.GetKey("d") && footprint.position.x < rightBound)
        {
          running = true;
          transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, 1f);
          moveX = 1f;
        }
        else
        {
          moveX = 0f;
        }

        if (Input.GetKey("w") && footprint.position.y < topBound)
        {
          running = true;
          moveY = 1f;
        }
        else if (Input.GetKey("s") && footprint.position.y > bottomBound)
        {
          running = true;
          moveY = -1f;
        }
        else
        {
          moveY = 0f;
        }

        if (moveX == 0 && moveY == 0)
        {
          running = false;
        }

        if (anim.GetBool("running") != running)
        {
          anim.SetBool("running", running);
        }

        // correct position: avoids jittering at boundaries
        if (footprint.position.x < leftBound)
        {
          transform.position = new Vector3(leftBound, transform.position.y, 0);
        }
        if (footprint.position.x > rightBound)
        {
          transform.position = new Vector3(rightBound, transform.position.y, 0);
        }
        if (footprint.position.y > topBound)
        {
          transform.position = new Vector3(transform.position.x, topBound + 1.5f * 0.2f, 0);
        }
        if (footprint.position.y < bottomBound)
        {
          transform.position = new Vector3(transform.position.x, bottomBound + 1.5f * 0.2f, 0);
        }

        GetComponent<Rigidbody2D>().velocity = new Vector3(moveX, moveY, 0) * Time.deltaTime * moveSpeed;

        if (Input.GetKeyDown("space") && Time.time >= cooldown)
        {
          Instantiate(bullet, barrel.position, Quaternion.Euler(0, 0, 180f * ((transform.localScale.x / transform.localScale.x) - 1f) / 2f));
          cooldown = Time.time + 0.6f;
        }
    }
}
