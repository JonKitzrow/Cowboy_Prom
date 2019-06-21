using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandit : MonoBehaviour
{
    public int health = 3;
    public float moveSpeed = 1f;
    public SpriteRenderer body, leftLeg, rightLeg;
    public ParticleSystem blood;
    bool dead = false;

    // Start is called before the first frame update
    void Start()
    {
      transform.position = new Vector3(10f, Random.Range(-4f, 0f), 0);
      body.sortingOrder -= (int)transform.position.y;
      leftLeg.sortingOrder -= (int)transform.position.y;
      rightLeg.sortingOrder -= (int)transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (health <= 0 && !dead)
        {
          dead = true;
          blood.Play();
          StartCoroutine(die());
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
      if (other.tag == "bullet")
      {
        Destroy(other.gameObject);
        health--;
      }
    }

    IEnumerator die()
    {
      GameObject.FindWithTag("GameController").GetComponent<GameController>().addScore(1);
      Destroy(body.transform.gameObject);
      yield return new WaitForSeconds(1);
      Destroy(transform.gameObject);
    }
}
