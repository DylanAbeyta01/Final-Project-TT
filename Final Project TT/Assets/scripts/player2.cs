using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class player2 : MonoBehaviour
{
    List<GameObject> bullets = new List<GameObject>();
    float speed = 2;
    float timer = 0;
    float timeToAction = 2;
    bool isCounting = false;
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

        for (int i = bullets.Count - 1; i >= 0; i--)
        {
            if (bullets[i] == null)
            {
                bullets.RemoveAt(i);
            }
        }

        if (bullets.Count < 5)
        {
            if (Input.GetKeyDown(KeyCode.M) && !isCounting)
            {
                ShootBallsPlayer2();
            }
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

        if (isCounting == true)
        {
            timer += Time.deltaTime;

            if (timer >= timeToAction)
            {
                Random rand = new Random();
                int rand1to5 = rand.Next(1, 4);

                SceneManager.LoadScene("Map " + rand1to5);
                timer = 0;
            }
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
            isCounting = true;
            GameManager.Instance.score1++;
            GetComponent<SpriteRenderer>().sprite = null;
            GetComponent<BoxCollider2D>().enabled = false;
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

        bullets.Add(newBullet);
    }
}
