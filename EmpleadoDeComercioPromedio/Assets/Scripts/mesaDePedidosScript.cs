using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mesaDePedidosScript : MonoBehaviour
{
    private int conteo = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ReposicionaHijos();
    }

    void ReposicionaHijos()
    {
       
        Vector3[] posicionEnLista = {transform.position + new Vector3(40f, 18, 0), transform.position + new Vector3(40f, 0, 0)};
        if(transform.childCount != conteo)
        {
            for(int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).transform.position = posicionEnLista[i];
            }
        }

        conteo = transform.childCount;

    }
}
