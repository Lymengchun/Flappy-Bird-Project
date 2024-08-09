using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{

    public Rigidbody2D rigidbody2d;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public float deadCameraZone = -4;
    public AudioSource jumpSFX;

    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<LogicScript>();
        jumpSFX.volume = 0.1f;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            BirdJump();
        }

        if (birdIsAlive)
        {
            anim.SetBool("isCrash", false);
        }
        else
        {
            anim.SetBool("isCrash", true);
        }

        DetectBirdStillInCamera();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameOver();
    }

    private void DetectBirdStillInCamera()
    {
        if (transform.position.y < deadCameraZone || transform.position.y > -deadCameraZone)
        {
                GameOver();
        }
    }

    private void GameOver()
    {
        if (birdIsAlive)
        {
            logic.GameOver();
            birdIsAlive = false;
        }
    }

    public void BirdJump()
    {
        if (birdIsAlive)
        {
            rigidbody2d.velocity = Vector2.up * flapStrength;
            jumpSFX.Play();
        }

    }



}
