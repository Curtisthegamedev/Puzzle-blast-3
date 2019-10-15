using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JetPackPlayerControl : MonoBehaviour
{
    [SerializeField] GameObject heart1, heart2, heart3, gunOne, gunTwo;

    private float speed = 50;

    private float moveX, moveY;

    [SerializeField] SpriteRenderer JetPackBoxSprite, TopPipeSprite, BottomPipeSprite;
    private Rigidbody2D rb; 

    private Collider2D myCollider;
    private bool isInvinsable = false; 

    private int JetPackLife;

    private void Awake()
    {
        gunOne.SetActive(true);
        gunTwo.SetActive(true); 
    }

    private void Start()
    {
        myCollider = this.gameObject.GetComponent<Collider2D>();
        rb = this.gameObject.GetComponent<Rigidbody2D>(); 

        JetPackLife = 3;
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true); 
    }

    private void FixedUpdate()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical"); 

        rb.velocity = new Vector2(moveX * speed, moveY * speed); 
    }

    private void Update()
    {
        if (JetPackLife > 3)
        {
            JetPackLife = 3; 
        }

        switch(JetPackLife)
        {
            case 3:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                break;
            case 2:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(false);
                break;
            case 1:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                break;
            case 0:
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                SceneManager.LoadScene("GameOverTwo"); 
                break; 
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "EProjectile" && !isInvinsable)
        {
            Destroy(col.gameObject);
            JetPackLife -= 1;
            StartCoroutine(TempInvinsibility());
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Obsticle")
        {
            JetPackLife = JetPackLife - 1; 
        }
        if(col.gameObject.tag == "LaserGun")
        {
            Destroy(col.gameObject); 
            gunOne.SetActive(true);
            gunTwo.SetActive(true); 
        }
        if (col.gameObject.tag == "EProjectile" && !isInvinsable)
        {
            Destroy(col.gameObject);
            JetPackLife -= 1;
            StartCoroutine(TempInvinsibility());
        }
    }

    private IEnumerator TempInvinsibility()
    {
        isInvinsable = true; 
        JetPackBoxSprite.color = new Color(1f, 1f, 1f, 0.5f);
        TopPipeSprite.color = new Color(1f, 1f, 1f, 0.5f);
        BottomPipeSprite.color = new Color(1f, 1f, 1f, 0.5f);
        yield return new WaitForSeconds(5);
        JetPackBoxSprite.color = new Color(1f, 1f, 1f, 1f);
        TopPipeSprite.color = new Color(1f, 1f, 1f, 1f);
        BottomPipeSprite.color = new Color(1f, 1f, 1f, 1f);
        isInvinsable = false; 
    }
}
