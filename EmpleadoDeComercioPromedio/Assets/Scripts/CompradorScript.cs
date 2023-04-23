using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedido {
    public int[] pedido = new int[2];
    public string solicitud;
    
    public Pedido(int it1, int it2, string solic){
        pedido[0] = it1;
        pedido[1] = it2;
        solicitud = solic;
    }

    
}

public class CompradorScript : MonoBehaviour
{
    private Pedido elPedido;
    
    // Start is called before the first frame update
    void Start()
    {
        
        elPedido = new Pedido(1, 2, "Necesito un firulete para sostener la repisa contra la pared. Me pregunto si en el bazar de enfrente venden repisas...");
       
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public Pedido GetPedido()
    {
        return elPedido;
    }
    
    public void MostrarSolicitud()
    {
        Debug.Log(elPedido.solicitud);
    }

}
