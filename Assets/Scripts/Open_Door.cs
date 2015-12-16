using UnityEngine;

public class Open_Door : MonoBehaviour
{
    private Vector3 door_position_temp;
    private Vector3 door_position;
    private void Start()
    {
        door_position = transform.position;
    }



    private void OnTriggerEnter(Collider other)
    {
      
        door_position_temp = new Vector3(transform.position.x, transform.position.y + 12.0f, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, door_position_temp, 5.0f * Time.deltaTime);
        Debug.Log("Pierdolnalem");

    }

    private void OnTriggerExit(Collider other)
    {
        
        transform.position = door_position;
        Debug.Log("Opuscilem Collider");
        Debug.Log(door_position);
        
    }
}

