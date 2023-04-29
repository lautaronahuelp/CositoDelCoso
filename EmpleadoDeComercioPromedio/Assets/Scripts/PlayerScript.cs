using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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

    private Transform unCliente;
    //private bool pedidoEnCurso = false;
    private Pedido pedidoActual;

    private string atendiendo;

    //private int estres = 50;
    
    // Start is called before the first frame update
    void Start()
    {
        Item.InicializaId();

     

    }

    // Update is called once per frame
    void Update()
    {
        if(filaDeClientes.transform.childCount > 0) ObtenerPedido();

        
        
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



    public void EntregaPedido()
    {
        //Debug.Log("PEDIDO ENTREGADO");
        int conteo = mesaDePedidos.transform.childCount;

        Debug.Log(ChequeaPedido());
        unCliente.GetComponent<CompradorScript>().Irse();
        
        //while(mesaDePedidos.transform.childCount == conteo);
        

    }

    public void EliminaItem(int id)
    {
     
    }

    

}
