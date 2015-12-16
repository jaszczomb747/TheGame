using UnityEngine;

public class Exploring_Rooms : MonoBehaviour
{
    public Transform door;
    private void Update()
    {
        if (transform != null)
        {
            if (door.position.y > 1f)
            {
                Destroy(gameObject);
            }
        }
    }
}