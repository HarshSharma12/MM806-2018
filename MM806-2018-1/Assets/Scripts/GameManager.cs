using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public AudioClip frustationEffect;

    public AudioSource source;
    Animator anim;                          // Reference to the animator component.

    void Awake()
    {
        // Set up the reference.
        anim = GetComponent<Animator>();
        //source = GetComponent<AudioSource>();
    }


    void Update()
    {
        if (IsOut(player.transform.position))
        {
            if (source.clip != frustationEffect)
            {
                source.clip = frustationEffect;
                source.Play(0);
            }
            anim.SetTrigger("GameOver");
            
        }
    }

    bool IsOut(Vector3 localPos)
    {
        return (localPos.y < -16);
    }
}