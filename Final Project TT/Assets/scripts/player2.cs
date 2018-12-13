using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class player2 : MonoBehaviour
{
    float speed = 2;
    public static int score1 = 0;
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

    //void OnCollisionEnter(Collision col)
    //{
    //    if (col.gameObject.name == "wally")
    //    {
    //        rbody.velocity = velocity * (speed - 1.15f);
    //    }
    //}
    //void OnCollisionExit(Collision collisionInfo)
    //{
    //    rbody.velocity = velocity * speed;
    //}

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
        if (Input.GetKeyDown(KeyCode.M))
        {
            ShootBallsPlayer2();
        }

        velocity.Normalize();
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rbody.velocity = velocity * (speed - 1.15f);
        }                     
        else
        {
            rbody.velocity = velocity * speed;
        }
    } 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "wally")
        {
            rbody.velocity = velocity * (speed - 1.5f);
        }

        if (collision.collider.tag == "bullet")
        {
            GameObject.DestroyImmediate(this.gameObject);

            score1++;
            Random rand = new Random();
            int rand1to5 = rand.Next(1, 3);

            SceneManager.LoadScene("Map " + rand1to5);
        }
        
    }

    public Vector3 LookAtDirection(float eulerAnglesZ)
    {
        return new Vector3(Mathf.Cos(eulerAnglesZ * Mathf.Deg2Rad), Mathf.Sin(eulerAnglesZ * Mathf.Deg2Rad), 0);
    }

    void ShootBallsPlayer2()
    {
        GameObject newBullet = Instantiate(BulletPrefab);
        newBullet.GetComponent<Bullet>().Initialize(transform.position + .3f * (LookAtDirection(transform.eulerAngles.z - 90).normalized),
            LookAtDirection(transform.eulerAngles.z - 90), Color.yellow);
    }
}
