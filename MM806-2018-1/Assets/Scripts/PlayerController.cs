using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text winText;

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
        if (score >= 50 && IsInGoal(rb.position))
        {
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
        }
        else if (other.gameObject.CompareTag("HighValuePickUp"))
        {
            other.gameObject.SetActive(false);
            score+=2;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("SpecialPickUp"))
        {
            other.gameObject.SetActive(false);
            score += 5;
            SetCountText();
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