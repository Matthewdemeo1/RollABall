 using UnityEngine;
 using UnityEngine.UI;
 using System.Collections;
 
 public class PlayerController : MonoBehaviour
 {
 
     public float speed;
     public Text countText;
     public Text winText;
     public Text scoreText;
     public Text livesText;
     public Text loseText;
     private Rigidbody rb;
     private int count;
     private int score; 
     private int lives;
 
     void Start()
     {
         rb = GetComponent<Rigidbody>();
         count = 0;
         score = 0;
         lives = 3;
         winText.text = "";
         scoreText.text = "";
         countText.text = "";
         livesText.text = "";
         loseText.text = "";
 
         SetAllText();   
     }
 
void Update ()
    {
        if (Input.GetKey("escape"))
     Application.Quit();
    }

     void FixedUpdate()
     {
         float moveHorizontal = Input.GetAxis("Horizontal");
         float moveVertical = Input.GetAxis("Vertical");
 
         Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
 
         rb.AddForce(movement * speed);
     }
 
     void OnTriggerEnter(Collider other)
     {
         if (other.gameObject.CompareTag("Pick Up"))
         {
             other.gameObject.SetActive(false);
             count++; 
             score++; 
             SetAllText();
         }
 
         else if (other.gameObject.CompareTag("Enemy"))
         {
             other.gameObject.SetActive(false);
             score--; 
             lives--;
             SetAllText();
         }
     }

     void SetAllText()
     {
         scoreText.text = "Score: " + score.ToString(); 
         livesText.text = "Lives: " + lives.ToString();
         countText.text = "Count: " + count.ToString();
         if (score >= 12)
         {
             winText.text = "You Win!";
         }
         if (lives == 0)
         {
             loseText.text = "You Lose!";
         }
 
     }
 }
