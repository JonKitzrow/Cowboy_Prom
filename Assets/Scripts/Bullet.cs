using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(Vector3.right) * Time.deltaTime * 500f;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
