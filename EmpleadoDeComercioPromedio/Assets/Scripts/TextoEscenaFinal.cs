using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextoEscenaFinal : MonoBehaviour
{
    private float estresFinal = EstadoDelJuego.estadoEstres;
    private TMP_Text textoFinal;
    private AudioSource audioSource;
    public AudioClip victoria;
    public AudioClip derrota;
    public AudioClip victoriaEstresada;
    public float volume=0.5f;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        textoFinal = GetComponent<TMP_Text>();
        if( estresFinal == 100)
        {
            textoFinal.text = "Le explotó la cabeza a Armando. Se va a tener que quedar un rato más limpiando y haciendo el inventario. Un garrón.";
            audioSource.PlayOneShot(derrota, volume);
        }
        else
        {
            if(estresFinal < 20)
            {
                textoFinal.text = "¡Lo logró! Armando surfeó la ola de clientes como un campeón y ahora ya es libre de ir a su casa y tomar una chocolatada. Bien por él";
                audioSource.PlayOneShot(victoria, volume);
            }
            else
            {
                textoFinal.text = "Llegó con lo justo. Pudo cerrar pero no hay chance de que esta noche descanse. Encima es lunes y la semana recién acaba de empezar…";
                audioSource.PlayOneShot(victoriaEstresada, volume);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
