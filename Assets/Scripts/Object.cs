using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Object : MonoBehaviour
{
    public enum ObjectType { TakeDrop, Read, Clean, TidyUp, OnOff};
    public Rigidbody rb;
    public Collider col;
    public ObjectType objectType;

    //el nuevo material puede ser un efecto o un shader, porque si cambio el material...

    [SerializeField] Material mat; //material original
    [SerializeField] Material newMat; //el material que va a tener al selecionarlo
    [SerializeField] string textToShow;
    [SerializeField] TextMeshProUGUI textUI;

    public Renderer rend; //protegida en el futuro

    public void IsObjectSelected(bool selected)
    {
        if (selected)
        {
            rend.material = newMat;
            textUI.text = textToShow;

        }
        else
        {
            rend.material = mat;
            textUI.text = "";
        }
    }
}
