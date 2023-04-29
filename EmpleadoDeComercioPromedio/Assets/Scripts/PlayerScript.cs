using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class Item {
    public string itemName;
    public int itemType;
    public int itemId;
    private static int UltId;


    public Item(string ina, int ity)
    {
        itemName = ina;
        itemType = ity;
        itemId = ++UltId;
    }

    public static void InicializaId()
    {
        UltId = 0;
    }

}

public class PlayerScript : MonoBehaviour
{
    public static int slotsNumber = 2;
    public GameObject mesaDePedidos, itemDePedido, filaDeClientes;
    public Transform cuadroTiempo;
    public Transform cuadroEstres;
    private TMP_Text textoTiempo;
    private TMP_Text textoEstres;
    private Transform unCliente;
    //private bool pedidoEnCurso = false;
    private Pedido pedidoActual;

    private string atendiendo;

    private float estres = 50;
    public float reduccionEstres = 10;
    public float tiempoAumentaEstres;
    private float tiempoAumentaEstresRest;
    public float aumentoEstres;
    public float aumentoEstresPedidoErroneo;

    public float tiempoRestante;
    
    // Start is called before the first frame update
    void Start()
    {
        Item.InicializaId();
        
        tiempoAumentaEstresRest = tiempoAumentaEstres;  
        //Debug.Log(tiempoAumentaEstresRest);
        textoTiempo = cuadroTiempo.GetComponent<TMP_Text>();
        textoEstres = cuadroEstres.GetComponent<TMP_Text>();
     

    }

    // Update is called once per frame
    void Update()
    {
        if(filaDeClientes.transform.childCount > 0) ObtenerPedido();
        PasaTiempo();
        AumentaEstresPorTiempo();
        MuestraTiempo(tiempoRestante);
        MuestraEstres();
        
        
        //Debug.Log(pedidoActual.pedido[0]);
        //Debug.Log(pedidoActual.pedido[1]);
        
        
    }

    public bool SetItem(Item unItem)
    {
        GameObject newItem;
        //Vector3 posicionRelativa;
   
        if(mesaDePedidos.transform.childCount < slotsNumber)
        {
            newItem = Instantiate(itemDePedido, mesaDePedidos.transform);
            newItem.GetComponent<ItemDePedidoScript>().SetItem(unItem.itemName, unItem.itemType, unItem.itemId, gameObject);
            return true;
            //posicionRelativa = mesaDePedidos.transform.childCount > 1 ? new Vector3(55.5f, 0, 0) : new Vector3(55.5f, 18, 0);
            //HACER REPOSICIONAMIENTO EN LA MESA DE PEDIDOS
            //newItem.transform.position = mesaDePedidos.transform.position + posicionRelativa;
        }
        
        return false;

    }


    private void ObtenerPedido()
    {
       // Debug.Log("busca pedido");
        unCliente = filaDeClientes.transform.GetChild(0);
        if(!unCliente.GetComponent<CompradorScript>().Entrego()){
            pedidoActual = unCliente.GetComponent<CompradorScript>().GetPedido();
            unCliente.GetComponent<CompradorScript>().MostrarSolicitud();
            atendiendo = unCliente.GetComponent<CompradorScript>().GetNombre();

        }
    }

    private int ChequeaPedido()
    {
        int[] elegidos = {-1, -1};
        int count = 0;
        for (int i = 0; i < mesaDePedidos.transform.childCount; i++)
        {
            elegidos[i] = mesaDePedidos.transform.GetChild(i).GetComponent<ItemDePedidoScript>().type;
        }

        for (int i = 0; i < slotsNumber; i++)
        {
            if(System.Array.IndexOf(elegidos, pedidoActual.pedido[i]) > -1) count++;
        }
        
        
        return count;
    
    }

    private void PasaTiempo()
    {
        if(tiempoRestante > 0)
        {
            tiempoRestante -= Time.deltaTime;
        }
        else
        {
            FinalDelJuego();
        }
    }

    private void AumentaEstresPorTiempo()
    {
        if(tiempoAumentaEstresRest > 0)
        {
            tiempoAumentaEstresRest -= Time.deltaTime;
        }
        else
        {
            AumentaEstres(aumentoEstres);
            tiempoAumentaEstresRest = tiempoAumentaEstres;
        }
    }

    private void AumentaEstres(float aum)
    {
        if(estres < 100) estres += aum;
        if(estres > 100)
        {
            
            estres = 100;
        }
        if(estres >= 100) FinalDelJuego();
    }
    

    private void MuestraTiempo(float tiempoEnPantalla)
    {
        tiempoEnPantalla += 1;
        float minutos = Mathf.FloorToInt(tiempoEnPantalla / 60); 
        float segundos = Mathf.FloorToInt(tiempoEnPantalla % 60);
        textoTiempo.text = string.Format("{0:00}:{1:00}", minutos, segundos);
    }

    private void MuestraEstres()
    {
        textoEstres.text = string.Format("{0:00}", estres);
    }


    public void EntregaPedido()
    {
        //Debug.Log("PEDIDO ENTREGADO");
        int conteo = mesaDePedidos.transform.childCount;
        int estadoPedido = ChequeaPedido();
        if(estres > 0 ) estres -= (reduccionEstres * estadoPedido);
        if(estres < 0) estres = 0;

        if(estadoPedido == 0) AumentaEstres(aumentoEstresPedidoErroneo);

        unCliente.GetComponent<CompradorScript>().Irse();
        filaDeClientes.GetComponent<FilaScript>().SeVaUno();
        for(int i = 0; i < conteo; i++){
            mesaDePedidos.transform.GetChild(i).GetComponent<ItemDePedidoScript>().EliminaItem();
        }
        //while(mesaDePedidos.transform.childCount == conteo);
        

    }

    public void FinalDelJuego()
    {
        Debug.Log("FINAL DEL JUEGO. ESTRES: "+ estres);
        EstadoDelJuego.estadoEstres = estres;
        filaDeClientes.GetComponent<FilaScript>().enabled = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    

}
