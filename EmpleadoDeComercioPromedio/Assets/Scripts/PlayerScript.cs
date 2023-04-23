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
    private int slotsLength = 0;
    public GameObject mesaDePedidos, itemDePedido, filaDeClientes;
    private GameObject newItem;
    private Item[] slots = new Item[2];
    private int[] itemsRendereados = new int[slotsNumber];

    private bool pedidoEnCurso = false;
    private Pedido pedidoActual;

    private int estres = 50;
    
    // Start is called before the first frame update
    void Start()
    {
        Item.InicializaId();

     

    }

    // Update is called once per frame
    void Update()
    {
        RenderSlots();

        ObtenerPedido();

        Debug.Log(ChequeaPedido());
        
        //Debug.Log(pedidoActual.pedido[0]);
        //Debug.Log(pedidoActual.pedido[1]);
        
        
    }

    public void SetItem(Item unItem)
    {
        if(slotsLength < slotsNumber) slots[slotsLength++] = unItem;  
    }

    private void RenderSlots()
    {
        bool rendereado;
        for (int i = 0; i < mesaDePedidos.transform.childCount; i++){
            itemsRendereados[i] = mesaDePedidos.transform.GetChild(i).GetComponent<ItemDePedidoScript>().id;
        }
        
        foreach(Item unItem in slots){
            if(unItem != null){
                rendereado = System.Array.IndexOf(itemsRendereados, unItem.itemId) > -1 ? true : false;

                if(!rendereado){
                    newItem = Instantiate(itemDePedido, mesaDePedidos.transform);
                    newItem.GetComponent<ItemDePedidoScript>().SetItem(unItem.itemName, unItem.itemType, unItem.itemId);
                    newItem.transform.position = mesaDePedidos.transform.position;
                }
            }
        }
    }

    private void ObtenerPedido()
    {
        Transform unCliente = filaDeClientes.transform.GetChild(0);
        if(!pedidoEnCurso){
            pedidoActual = unCliente.GetComponent<CompradorScript>().GetPedido();
            unCliente.GetComponent<CompradorScript>().MostrarSolicitud();
            pedidoEnCurso = true;

        }
    }

    private bool ChequeaPedido()
    {
        if(pedidoActual.pedido[0] == slots[0].itemType && pedidoActual.pedido[1] == slots[1].itemType)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
