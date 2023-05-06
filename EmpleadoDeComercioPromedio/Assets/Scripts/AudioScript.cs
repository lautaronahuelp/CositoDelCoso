using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public float delay = 1f;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().PlayDelayed(delay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
