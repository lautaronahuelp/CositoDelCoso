using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AjustesScript : MonoBehaviour
{
    public Transform elPlayer = null;
    public Transform laFila = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GuardaAjustes()
    {
        if(elPlayer != null) elPlayer.GetComponent<PlayerScript>().CargaAjustes();
        //if(laFila != null) laFila.CargaAjustes();
    }
}
