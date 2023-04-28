using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemDePedidoScript : MonoBehaviour
{
    public string itemName;
    public int type;
    public int id;
    public GameObject player;
    public AudioClip clip;
    public float volumen = 1f;
    private TMP_Text mText;
    // Start is called before the first frame update
    void Start()
    {
        mText = gameObject.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        mText.text = itemName;
    }

    public void SetItem(string n, int t, int i, GameObject pl)
    {
        itemName = n;
        type = t;
        id = i;
        player = pl;
    }

    public void EliminaItem(){
        Debug.Log("ELIMINAR");
        AudioSource.PlayClipAtPoint(clip, new Vector3(-13.84000015258789f, 0.21999996900558473f, -1.9800000190734864f), volumen);
        Destroy(gameObject);
    }
}
