using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class player1 : MonoBehaviour
{
    List<GameObject> bullets = new List<GameObject>();
    float speed = 2;
    float fricSpeed = 1.5f;
    float curSpeed = 2;
    int score2 = 0;
    Vector3 velocity = new Vector3(0, 0, 0);
    Rigidbody2D rbody;
    public GameObject BulletPrefab;

    private void Awake()
    {
        GameManager.Instance.MyCharacter1 = this;
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

        if (Input.GetKey(KeyCode.S))
        {
            transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z + 200 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.F))
        {
            transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z - 200 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E))
        {
            velocity += LookAtDirection(transform.eulerAngles.z - 90);
        }
        if (Input.GetKey(KeyCode.D))
        {
            velocity -= LookAtDirection(transform.eulerAngles.z - 90);
        }

        for (int i = bullets.Count-1; i >= 0; i--)
        {
            if (bullets[i] == null)
            {
                bullets.RemoveAt(i);
            }
        }

        if (bullets.Count < 5)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                ShootBallsPlayer1();
            }
        }

        velocity.Normalize();

        if (Input.GetKey(KeyCode.D))
        {
            rbody.velocity = velocity * (curSpeed - 1.15f);
        }
        else
        {
            rbody.velocity = velocity * curSpeed;
        }
    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "wally")
        {
            rbody.velocity = velocity * (curSpeed - 1.5f);
        }

        if (collision.collider.tag == "bullet")
        {
            score2++;
            Random rand = new Random();
            int rand1to5 = rand.Next(1, 4);

            SceneManager.LoadScene("Map " + rand1to5);
        }
    }

    public Vector3 LookAtDirection(float eulerAnglesZ)
    {
        return new Vector3(Mathf.Cos(eulerAnglesZ * Mathf.Deg2Rad), Mathf.Sin(eulerAnglesZ * Mathf.Deg2Rad), 0);
    }

    void ShootBallsPlayer1()
    {
        GameObject newBullet = Instantiate(BulletPrefab);
        newBullet.GetComponent<Bullet>().Initialize(transform.position + .3f * (LookAtDirection(transform.eulerAngles.z - 90).normalized),
            LookAtDirection(transform.eulerAngles.z - 90), Color.green);

        bullets.Add(newBullet);
    }
}