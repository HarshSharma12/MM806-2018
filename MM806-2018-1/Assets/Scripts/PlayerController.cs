using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text winText;
    public AudioSource source;

    public AudioClip sound1;
    public AudioClip sound2;
    public AudioClip sound3;
    public AudioClip winSound;

    private Rigidbody rb;
    private int score;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;
        SetCountText();
        winText.text = "";
    }


    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
        if (score >= 10 && IsInGoal(rb.position))
        {
            if (source.clip != winSound)
            {
                source.clip = winSound;
                source.Play(0);
            }
            SetWinText();
        }

        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("LowValuePickUp"))
        {
            other.gameObject.SetActive(false);
            score++;
            SetCountText();
            source.clip = sound1;
            source.Play(0);
        }
        else if (other.gameObject.CompareTag("HighValuePickUp"))
        {
            other.gameObject.SetActive(false);
            score+=2;
            SetCountText();
            source.clip = sound2;
            source.Play(0);
        }
        else if (other.gameObject.CompareTag("SpecialPickUp"))
        {
            other.gameObject.SetActive(false);
            score += 5;
            SetCountText();
            source.clip = sound3;
            source.Play(0);
        }
    }

    void SetCountText()
    {
        countText.text = "Current Score: " + score.ToString();
    }
    void SetWinText()
    {
        winText.text = "You Win!";
    }

    
    bool IsInGoal(Vector3 localPos)
    {
        print(localPos);
        if (localPos.y <= -10.5 && localPos.y >= -14.5 && localPos.x <= 91 && localPos.x >= 84 && localPos.z <= -83 && localPos.z >= -90)
        {
            return true;
        }
        return false;
    }

    
}