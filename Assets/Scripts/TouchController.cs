using UnityEngine;
using System.Collections;

public class TouchController : MonoBehaviour
{

    void Start()
    {

    }


    void FixedUpdate()
    {
        if(Input.touchCount > 0)
        {
            foreach(Touch touch in Input.touches)
            {

            }
        }
    }
}