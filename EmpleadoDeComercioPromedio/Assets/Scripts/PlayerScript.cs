using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    public Image medidorEstres;
    public Button botonEntrega;
    private TMP_Text textoTiempo;
    private TMP_Text textoEstres;
    private Transform unCliente;
    //private bool pedidoEnCurso = false;
    private Pedido pedidoActual;

    private string atendiendo;

    public float estresInicial;
    public float tiempoAumentaEstres;
    private float tiempoAumentaEstresRest;
    public float aumentoEstresXTiempo;
    public float aumentoEstresPedidoErroneo;
    public float reduccionEstresPedidoCorrecto;

    public float tiempoRestante;
    private float sumaDeTiempo;
    
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
        MuestraTiempo(sumaDeTiempo);
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
        unCliente = filaDeClientes.transform.GetChild(0);
        bool clienteListo = unCliente.GetComponent<CompradorScript>().ListoParaCompra();
        
        //Debug.Log("OBTENER PEDIDO "+!unCliente.GetComponent<CompradorScript>().Entrego()+"|"+unCliente.GetComponent<CompradorScript>().ListoParaCompra());
        if(clienteListo) botonEntrega.interactable = true;
        if(!unCliente.GetComponent<CompradorScript>().Entrego() && clienteListo){
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
        if( sumaDeTiempo < tiempoRestante)
        {
            sumaDeTiempo += Time.deltaTime;
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
            AumentaEstres(aumentoEstresXTiempo);
            tiempoAumentaEstresRest = tiempoAumentaEstres;
        }
    }

    private void AumentaEstres(float aum)
    {
        if(estresInicial < 100) estresInicial += aum;
        if(estresInicial > 100)
        {
            
            estresInicial = 100;
        }
        if(estresInicial >= 100) FinalDelJuego();
    }

     private void ReduceEstres(float red)
    {
        if(estresInicial > 0) estresInicial -= red;
        if(estresInicial < 0) estresInicial = 0;
    
    }
    

    private void MuestraTiempo(float tiempoEnPantalla)
    {
    
        float minTot = 60f - (float)(int)(tiempoRestante / 60);
        
        float horTot = 17f;
        //tiempoEnPantalla += 1;
        float minutos = Mathf.FloorToInt(tiempoEnPantalla / 60); 
        float segundos = Mathf.FloorToInt(tiempoEnPantalla % 60);
        minTot += minutos;
        

        if( minTot == 60 ) 
        {
            minTot = 0;
            horTot = 18;
        }
        if( segundos == 60 ) segundos = 0;
        
        textoTiempo.text = string.Format("{0:00}:{1:00}:{2:00}", horTot, minTot, segundos );
    }

    private void MuestraEstres()
    {
        textoEstres.text = string.Format("{0:00}", estresInicial);
        medidorEstres.fillAmount = estresInicial / 100;
        medidorEstres.color = new Color(0.475f, 1f, 0f, 1f);
        if(estresInicial > 20)
        {
            medidorEstres.color = new Color(1f, 0.529f, 0f, 1f);
        }

        if(estresInicial > 80)
        {
            medidorEstres.color = new Color(1f, 0f, 0f, 1f);
        }
        
    }


    public void EntregaPedido()
    {
        //Debug.Log("PEDIDO ENTREGADO");
        int conteo = mesaDePedidos.transform.childCount;
        int estadoPedido = ChequeaPedido();
        
        botonEntrega.interactable = false;

        if(estadoPedido != 2) AumentaEstres(aumentoEstresPedidoErroneo); else ReduceEstres(reduccionEstresPedidoCorrecto);

        unCliente.GetComponent<CompradorScript>().Irse();
        filaDeClientes.GetComponent<FilaScript>().SeVaUno();
        for(int i = 0; i < conteo; i++){
            mesaDePedidos.transform.GetChild(i).GetComponent<ItemDePedidoScript>().EliminaItem();
        }
        //while(mesaDePedidos.transform.childCount == conteo);
        

    }

    public void FinalDelJuego()
    {
        Debug.Log("FINAL DEL JUEGO. ESTRES: "+ estresInicial);
        EstadoDelJuego.estadoEstres = estresInicial;
        filaDeClientes.GetComponent<FilaScript>().enabled = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    

}
