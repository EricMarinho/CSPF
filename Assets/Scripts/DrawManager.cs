using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawManager : MonoBehaviour
{

    public GameObject carta1;
    public GameObject carta2;
    public GameObject handManager;

    //    public struct cardsStruct
    //  {
    //     public float calculo;
    //     public string type;
    //     public GameObject cardObject;
    //  }
    List<GameObject> cardsList = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(setarMao());
        cardsList.Add(carta1);
        cardsList.Add(carta2);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        

    }

    public void Draw(){

        GameObject carta = Instantiate(cardsList[Random.Range(0, cardsList.Count)], new Vector3(0,0,0),Quaternion.identity);
        carta.transform.SetParent(handManager.transform, false);

    }

    IEnumerator setarMao(){
        for(var i = 0; i < 4; i++){
            yield return new WaitForSeconds(1);
            Draw();
        }
    }

}
