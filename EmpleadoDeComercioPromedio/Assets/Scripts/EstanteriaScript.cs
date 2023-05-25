using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EstanteriaScript : MonoBehaviour
{
    public GameObject playerObject;
    public WayPoints waypointsToThis;
    public GameObject itemSprite;
    private GameObject spriteActual;
    public TMP_Text texto;
    public Canvas elCanvas;
    public string nombreItem;
    public int idItem;
    private WaypointMover waypointMover;
    private Item elItem;
    private AudioSource audioSource;
    

    // Start is called before the first frame update
    void Start()
    {
        waypointMover = playerObject.GetComponent<WaypointMover>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown(){
        if(EstadoDelJuego.habilitaJuego) playerObject.GetComponent<WaypointMover>().Camina(waypointsToThis);
        
        
    }

    void OnTriggerEnter(Collider player)
    {
        elItem = new Item(nombreItem, idItem);
        if(player.gameObject.GetComponentInParent<PlayerScript>().SetItem(elItem)) audioSource.Play();
    }

    void OnMouseEnter()
    {
        spriteActual = Instantiate(itemSprite, elCanvas.transform);
    }

    void OnMouseOver()
    {
        
        spriteActual.GetComponent<RectTransform>().transform.position = Input.mousePosition + new Vector3(-12, 12, 0);
        texto.text = nombreItem;
        switch(playerObject.GetComponent<PlayerScript>().pasada)
        {
            case 1:
                spriteActual.GetComponent<Image>().color = new Color(0, 0, 0, 255);
                texto.text = "";
                break;
            case 2:
                spriteActual.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                texto.text = "";
                break;
            default:
                break;
        }
        
    }

    void OnMouseExit()
    {
        texto.text = "";
        Destroy(spriteActual);
    }
}
