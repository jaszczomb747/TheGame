using UnityEngine;
using UnityEngine.UI;

public class Show_Hints : MonoBehaviour
{
    //private int display_width;
    // private int display_height;
    //public Transform Room1;

    //public Transform Room2;
    //public Transform Room3;
    public Text hint;

    //private void Start()
    //{
    // display_height = Screen.height;
    // display_width = Screen.width;
    //!TO CHECK!//
    //Ustawienie na środku napisu
    // }

    private void OnTriggerEnter(Collider other)
    {
        
        if (transform.name == "Room1")
        {
            Debug.Log("1");
            hint.text = "Room1";
        }
        else if (transform.name == "Room2")
        {
            Debug.Log("2");
            hint.text = "Room2";
        }
        else if (transform.name == "Room3")
        {
            Debug.Log("3");
            hint.text = "Room3";
        }
        else if (transform.name == "Room4")
        {
            Debug.Log("4");
          hint.text = "Room4";
        }
    }
}