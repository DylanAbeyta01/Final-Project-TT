﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2 : MonoBehaviour
{
    float speed = 2;
    Vector3 velocity = new Vector3(0, 0, 0);
    Rigidbody2D rbody;
    public GameObject BulletPrefab;

    private void Awake()
    {
        GameManager.Instance.MyCharacter2 = this;
    }

    // Use this for initialization
    void Start() 
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        velocity = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z + 200 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z - 200 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            velocity += LookAtDirection(transform.eulerAngles.z - 90);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            velocity -= LookAtDirection(transform.eulerAngles.z - 90);
        }

        velocity.Normalize();
        rbody.velocity = velocity * speed;
    }
    public Vector3 LookAtDirection(float eulerAnglesZ)
    {
        return new Vector3(Mathf.Cos(eulerAnglesZ * Mathf.Deg2Rad), Mathf.Sin(eulerAnglesZ * Mathf.Deg2Rad), 0);
    }

    void ShootBalls()
    {
        transform.position += velocity * Time.deltaTime * speed;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameObject newBullet = Instantiate(BulletPrefab);
            newBullet.GetComponent<Bullet>().Initialize(transform.position, LookAtDirection(transform.eulerAngles.z - 90), Color.green);
        }
    }
}
