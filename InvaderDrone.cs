using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvaderDrone : MonoBehaviour
{
    private Rigidbody2D rb;
    private int randomNumber;
    private float lastBoltSpawnTime;
    private Vector2 upVel = new Vector2(-3, 3), downVel = new Vector2(-3, -3); 
    private float moveRightSpeed = 1, moveUpAndDownSpeed = 5, ShootRate = 2.0f, 
        coundownTillShoot = 0.0f;
    private bool atTopOfMovementPath = true; 
    [SerializeField] Transform BoltSpawn;
    [SerializeField] Rigidbody2D redbolt; 

    private void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    private void ShootPlayer()
    {
        Instantiate(redbolt, BoltSpawn.position, BoltSpawn.rotation); 
    }

    private void moveUpAndDown()
    {
        if (atTopOfMovementPath)
        {
            rb.MovePosition(rb.position + downVel * Time.fixedDeltaTime); 
        }
        else if(!atTopOfMovementPath)
        {
            rb.MovePosition(rb.position + upVel * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        if(c.gameObject.tag == "TopDroneTrigger")
        {
            atTopOfMovementPath = true; 
        }

        if(c.gameObject.tag == "BottomDroneTrigger")
        { 
            atTopOfMovementPath = false; 
        }

        if (c.gameObject.tag == "LaserBolt")
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    { 
        moveUpAndDown(); 
        if (coundownTillShoot <=  0.0f)
        {
            ShootPlayer();
            coundownTillShoot = 3.5f / ShootRate; 
        }

        coundownTillShoot -= Time.deltaTime; 
    }
}
