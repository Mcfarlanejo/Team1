using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    Animation anim;
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animation>();
    }

    public void Play()
    {
        anim.Stop();
        anim.Rewind();
        anim.Play();
    }
}
