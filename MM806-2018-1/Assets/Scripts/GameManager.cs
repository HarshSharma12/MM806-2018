using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    Animator anim;                          // Reference to the animator component.
    void Awake()
    {
        // Set up the reference.
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (IsOut(player.transform.position))
        {
            //SetLoseText();
            anim.SetTrigger("GameOver");
        }
    }

    bool IsOut(Vector3 localPos)
    {
        return (localPos.y < -16);
    }
}