using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Globalization;
using UnityEngine.SceneManagement;

public class AjustesScript : MonoBehaviour
{
    public Transform elPlayer = null;
    public Transform laFila = null;


    
    // Start is called before the first frame update
    void Start()
    {
        AbreAjustes();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void AbreAjustes()
    {
        if(elPlayer != null) elPlayer.GetComponent<PlayerScript>().GuardaAjustes();
        transform.GetChild(0).GetComponent<TMP_InputField>().text = EstadoDelJuego.estresInicial.ToString();
        transform.GetChild(1).GetComponent<TMP_InputField>().text = EstadoDelJuego.tiempoAumentaEstres.ToString();
        transform.GetChild(2).GetComponent<TMP_InputField>().text = EstadoDelJuego.aumentoEstresXTiempo.ToString();
        transform.GetChild(3).GetComponent<TMP_InputField>().text = EstadoDelJuego.aumentoEstresPedidoErroneo.ToString();
        transform.GetChild(4).GetComponent<TMP_InputField>().text = EstadoDelJuego.aumentoEstresMedioPedido.ToString();
        transform.GetChild(5).GetComponent<TMP_InputField>().text = EstadoDelJuego.reduccionEstresMedioPedido.ToString();
        transform.GetChild(6).GetComponent<TMP_InputField>().text = EstadoDelJuego.reduccionEstresPedidoCorrecto.ToString();
        transform.GetChild(7).GetComponent<TMP_InputField>().text = EstadoDelJuego.tiempoDePartida.ToString();
        
    }

    public void GuardaAjustes()
    {
        EstadoDelJuego.estresInicial = float.Parse(transform.GetChild(0).GetComponent<TMP_InputField>().text, NumberStyles.Any, new CultureInfo("en-US"));
        EstadoDelJuego.tiempoAumentaEstres = float.Parse(transform.GetChild(1).GetComponent<TMP_InputField>().text, NumberStyles.Any, new CultureInfo("en-US"));
        EstadoDelJuego.aumentoEstresXTiempo = float.Parse(transform.GetChild(2).GetComponent<TMP_InputField>().text, NumberStyles.Any, new CultureInfo("en-US"));
        EstadoDelJuego.aumentoEstresPedidoErroneo = float.Parse(transform.GetChild(3).GetComponent<TMP_InputField>().text, NumberStyles.Any, new CultureInfo("en-US"));
        EstadoDelJuego.aumentoEstresMedioPedido = float.Parse(transform.GetChild(4).GetComponent<TMP_InputField>().text, NumberStyles.Any, new CultureInfo("en-US"));
        EstadoDelJuego.reduccionEstresMedioPedido = float.Parse(transform.GetChild(5).GetComponent<TMP_InputField>().text, NumberStyles.Any, new CultureInfo("en-US"));
        EstadoDelJuego.reduccionEstresPedidoCorrecto = float.Parse(transform.GetChild(6).GetComponent<TMP_InputField>().text, NumberStyles.Any, new CultureInfo("en-US"));
        EstadoDelJuego.tiempoDePartida = float.Parse(transform.GetChild(7).GetComponent<TMP_InputField>().text, NumberStyles.Any, new CultureInfo("en-US"));

        if(elPlayer != null) elPlayer.GetComponent<PlayerScript>().CargaAjustes();
        if(laFila != null) laFila.GetComponent<FilaScript>().CargaAjustes();
        CancelarAjustes();
    }

    public void CancelarAjustes()
    {
        EstadoDelJuego.habilitaJuego = true;
        Destroy(transform.gameObject);
    }

    public void GuardaYReinicia()
    {
        EstadoDelJuego.estresInicial = float.Parse(transform.GetChild(0).GetComponent<TMP_InputField>().text, NumberStyles.Any, new CultureInfo("en-US"));
        EstadoDelJuego.tiempoAumentaEstres = float.Parse(transform.GetChild(1).GetComponent<TMP_InputField>().text, NumberStyles.Any, new CultureInfo("en-US"));
        EstadoDelJuego.aumentoEstresXTiempo = float.Parse(transform.GetChild(2).GetComponent<TMP_InputField>().text, NumberStyles.Any, new CultureInfo("en-US"));
        EstadoDelJuego.aumentoEstresPedidoErroneo = float.Parse(transform.GetChild(3).GetComponent<TMP_InputField>().text, NumberStyles.Any, new CultureInfo("en-US"));
        EstadoDelJuego.aumentoEstresMedioPedido = float.Parse(transform.GetChild(4).GetComponent<TMP_InputField>().text, NumberStyles.Any, new CultureInfo("en-US"));
        EstadoDelJuego.reduccionEstresMedioPedido = float.Parse(transform.GetChild(5).GetComponent<TMP_InputField>().text, NumberStyles.Any, new CultureInfo("en-US"));
        EstadoDelJuego.reduccionEstresPedidoCorrecto = float.Parse(transform.GetChild(6).GetComponent<TMP_InputField>().text, NumberStyles.Any, new CultureInfo("en-US"));
        EstadoDelJuego.tiempoDePartida = float.Parse(transform.GetChild(7).GetComponent<TMP_InputField>().text, NumberStyles.Any, new CultureInfo("en-US"));
        
        EstadoDelJuego.habilitaJuego = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
