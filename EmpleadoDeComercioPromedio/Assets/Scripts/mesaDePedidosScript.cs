using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mesaDePedidosScript : MonoBehaviour
{
    private int conteo = 0;
    private float x = 55f;
    private float y = 5f;
    private float dist = 13f;
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
       
        Vector3[] posicionEnLista = {new Vector3(x, y, 0), new Vector3(x, (y - dist), 0)};
        if(transform.childCount != conteo)
        {
            for(int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).localPosition = posicionEnLista[i];
            }
        }

        conteo = transform.childCount;

    }
}
