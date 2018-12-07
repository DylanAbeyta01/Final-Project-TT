using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 velocity = new Vector3(0, 0, 0);
    float speed = 7f;

    // Use this for initialization
    void Start()
    {
        //velocity = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += velocity * Time.deltaTime * speed;

        float distance = Vector3.Distance(transform.position, GameManager.Instance.MyCharacter1.transform.position);

        if (Time.deltaTime > 7)
        {
            GameObject.DestroyImmediate(gameObject, true);
        }
    }
}