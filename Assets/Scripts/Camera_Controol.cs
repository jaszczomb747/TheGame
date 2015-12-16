using UnityEngine;

public class Camera_Controol : MonoBehaviour
{
    public float smooth = 10;
    public float distanceX = 10;
    public float distanceY = 32;
    public float distanceZ = 10;

    public Transform hero;

    private void Start()
    {
    }

    private void FixedUpdate()
    {
        Vector3 target_camera_position;

        target_camera_position = new Vector3(hero.position.x - distanceX, distanceY, hero.position.z + distanceZ);
        transform.position = Vector3.Lerp(transform.position, target_camera_position, smooth * Time.deltaTime);
        transform.LookAt(hero);
        //Rotacje można na sztywno ustawić.
    }
}