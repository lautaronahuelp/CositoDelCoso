using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoDelJuego : MonoBehaviour
{
    public static float estadoEstres;

    public static float estresInicial = 50;
    public static float tiempoAumentaEstres = 15;
    public static float aumentoEstresXTiempo = 5;
    public static float aumentoEstresPedidoErroneo = 10;
    public static float aumentoEstresMedioPedido = 0;
    public static float reduccionEstresMedioPedido = 0;
    public static float reduccionEstresPedidoCorrecto = 10;
    public static float tiempoDePartida = 300;
    
    public static float tiempoDeSpawneo = 5;
    public static bool habilitaJuego = true;
}
