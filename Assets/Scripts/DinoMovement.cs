using UnityEngine.UI;
using UnityEngine;

public class DinoMovement : MonoBehaviour
{

    public Text CurrentScore;
    public Text HighScore;
    int Score = 0;
    private float counter = 0f;


    public float Jump = 900f;
    Rigidbody2D myRigidBody;
    bool isGround = false;
    public static Animator animator;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        HighScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        IncreaseScore();
    }

    void IncreaseScore()
    {
        if (ParallaxScroll.EndGame == false)
        {
            Score++;
            counter = 0.1f;

            CurrentScore.text = Score.ToString();

            if (Score > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", Score);
                HighScore.text = PlayerPrefs.GetInt("HighScore").ToString();
            }
        }
    }

    void Update()
    {
        if(ParallaxScroll.EndGame == false)
        {
            if (counter <= 0)
            {
                IncreaseScore();
            }
            else
            {
                counter -= Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.Space) && isGround)
            {
                //Jump
                myRigidBody.AddForce(Vector2.up * Jump);
                isGround = false;
                animator.SetBool("Jump", true);
            }

            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.DownArrow) && isGround)
            {
                animator.SetBool("Duck", true);
            }

            if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.DownArrow))
            {
                animator.SetBool("Duck", false);
            }
        } else
        {
            animator.SetBool("GameOver", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGround = true;
            animator.SetBool("Jump", false);
        }

        if (collision.collider.tag == "Enemy")
        {
            ParallaxScroll.EndGame = true;
            FindObjectOfType<GameScore>().GameOver();
        }
    }
}
