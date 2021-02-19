using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour {

    private Camera cam;
    private int angleAfterTest = 0;
    private bool testAngle = false;
    private float angel=50f;
    public Text scoreText;
    private int points;
    public Rigidbody2D rb;
    public AudioSource myAudio;
    public float moveSpeed;
    public float flapHeight;
    public GameObject pipe_up;
    public GameObject pipe_down;

    
    // Use this for initialization
    void Start () {
        moveSpeed = 7;
        flapHeight = 5;
        points = 0;

        cam = GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();

        BuildLevel();
    }

    void BuildLevel()
    {
        Instantiate(pipe_down, new Vector3(14, 10), transform.rotation);
        Instantiate(pipe_up, new Vector3(14, -10), transform.rotation);

        Instantiate(pipe_down, new Vector3(22, 5), transform.rotation);
        Instantiate(pipe_up, new Vector3(22, -15), transform.rotation);

        Instantiate(pipe_down, new Vector3(34, 0), transform.rotation);
        Instantiate(pipe_up, new Vector3(34, -20), transform.rotation);

        Instantiate(pipe_down, new Vector3(46, 8), transform.rotation);
        Instantiate(pipe_up, new Vector3(46, -12), transform.rotation);

        Instantiate(pipe_down, new Vector3(57, 6), transform.rotation);
        Instantiate(pipe_up, new Vector3(57, -14), transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        ++points;
        scoreText.text = "Score: " + points.ToString();


        if (points == 500)
        {
            moveSpeed += 4;
            flapHeight += 3;
        }
        if (points == 1000)
        {
            moveSpeed += 4;
            flapHeight+=2;
        }

        if (points==2000)
        {
            moveSpeed += 4;
            flapHeight+=2;
        }

        if (points == 4000)
        {
            moveSpeed += 2;
            flapHeight++;
        }

        if (Input.GetMouseButtonDown(0))
        {
            myAudio.Play();
            rb.velocity = new Vector2(rb.velocity.x, flapHeight);

            if(testAngle==false)
            {
                angel = Mathf.Lerp(0, 0, rb.velocity.y / 7);
                transform.rotation = Quaternion.Euler(0, 0, angel);
            }
            testAngle = true;
        }

       /* if(testAngle)
        {
            if (angleAfterTest <= 90)
            {
                angel = Mathf.Lerp(0, angleAfterTest++, rb.velocity.y / 7);
                rb.transform.rotation = Quaternion.Euler(0, 0, angel);
                cam.transform.rotation = Quaternion.Euler(0, 0, 0);
                
            }
            else
            {
                testAngle = false;
                angleAfterTest = 0;
            }
        }*/

        

        if (transform.position.y > 18 || transform.position.y <= -19)
        {
            Death();
        }
    }


    public void Death()
    {
        if (points > PlayerPrefs.GetInt("LevelHardScore"))
        {
            PlayerPrefs.SetInt("LevelHardScore", points);
            PlayerPrefs.Save();
        }


        //the27.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}