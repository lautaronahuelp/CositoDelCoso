using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSoundScript : MonoBehaviour
{
    public AudioClip clip;
    public AudioSource source;
    public float volumen = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickEnBoton()
    {
        source.PlayOneShot(clip, volumen);
        //AudioSource.PlayClipAtPoint(clip, new Vector3(-13.84000015258789f, 0.21999996900558473f, -1.9800000190734864f), volumen);
    }
}
