using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class  ResultScript : MonoBehaviour
{
    public ResultScriptableObject scriptableObject;
    [SerializeField]//let to touch objects in order to show them in the editot
    public List< ResultHandler> resultHandlers; //gonna stock all the texte of the ui
    
   

    // Update is called once per frame
    void Update()
    {

        UpdateTextQst();
    }
    void UpdateTextQst()
    {
       Debug.Log( scriptableObject.GetResults());


    }


}
