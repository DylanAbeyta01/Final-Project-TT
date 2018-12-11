using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float timer = 0;
    float timeToAction = 3;
    public Vector3 velocity = new Vector3(0, 0, 0);
    public GameObject BulletPrefab;
    float speed = 3f;

    // Use this for initialization
    void Start()
    {
        //velocity = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
    }

    /// <summary>
    /// Initialize the ball
    /// </summary>
    /// <param name="position">Position to spawn</param>
    /// <param name="velocity">Direction * speed</param>
    /// <param name="color">Color of the ball</param>
    /// 
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeToAction)
        {
            GameObject.DestroyImmediate(this.gameObject);
            timer = 0;
        }
    }

    public void Initialize(Vector3 position, Vector3 velocity, Color color)
    {
        this.transform.position = position;
        this.velocity = velocity;
        GetComponent<SpriteRenderer>().color = color;
        GetComponent<Rigidbody2D>().velocity = velocity * speed;
    }
}