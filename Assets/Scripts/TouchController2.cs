using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TouchController2 : MonoBehaviour
{
    private Transform moveButton;
    private Transform moveAnalog;
    private Transform lookButton;
    private Transform lookAnalog;
    private GameObject player;
    private Rigidbody playerRigidbody;

    PointerEventData pointer;

    private GameObject[] UIElement;
    private Vector3[] direction;

    public Text text;

    public float speed = 20.0f;
    float buttonRadius = 80.0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRigidbody = player.GetComponent<Rigidbody>();
        moveButton = transform.GetChild(0);
        moveAnalog = transform.GetChild(0).GetChild(0);
        lookButton = transform.GetChild(1);
        lookAnalog = transform.GetChild(1).GetChild(0);

        pointer = new PointerEventData(EventSystem.current);
        UIElement = new GameObject[5];
        direction = new Vector3[5];
    }

    //void Update()
    //{
    //text.text = EventSystem.current.currentSelectedGameObject.ToString();

    /*if (EventSystem.current.IsPointerOverGameObject(-3))
    {
        Debug.Log("ja pierdole");
    }

    GameObject button = pointer.pointerPress;
    if(button) Debug.Log(button.name);
    Debug.Log(pointer.pointerId);*/

    //text.text = pointer.pointerId.ToString();

    //Debug.Log(EventSystem.current.currentSelectedGameObject);
    //}

    void FixedUpdate()
    {
        for(int i = 0; i < UIElement.Length; i++)
        {
            if(UIElement[i] != null)
            {
                if (UIElement[i] == moveButton.gameObject)
                {
                    bool checkIfLookButtonIsPressed = false;
                    for(int j = 0; j < direction.Length; j++)
                    {
                        if(UIElement[j] == lookButton.gameObject)
                        {
                            checkIfLookButtonIsPressed = true;
                            break;
                        }
                    }
                    if(checkIfLookButtonIsPressed == false)
                    {
                        player.transform.forward = direction[i];
                    }
                    playerRigidbody.MovePosition(player.transform.position + direction[i] * Time.deltaTime * speed);
                }
                else if (UIElement[i] == lookButton.gameObject)
                {
                    player.transform.forward = direction[i];
                }
            }
        }

#if UNITY_EDITOR
        //mouse
        //if (EventSystem.current.IsPointerOverGameObject())
        //{
        if (Input.GetButton("Fire1"))
        {
            if (EventSystem.current.currentSelectedGameObject == moveButton.gameObject)
            {
                Vector2 pos = Input.mousePosition;

                Vector2 moveDir = pos - new Vector2(moveButton.position.x, moveButton.position.y);
                Vector3 worldMoveDir = new Vector3(moveDir.x, player.transform.position.y, moveDir.y);
                Vector3 normalizedWorldMoveDir = worldMoveDir.normalized;
                normalizedWorldMoveDir.y = 0.0f;

                player.transform.forward = normalizedWorldMoveDir;
                playerRigidbody.MovePosition(player.transform.position + normalizedWorldMoveDir * Time.deltaTime * speed);

                pos = moveButton.position + Vector3.ClampMagnitude(moveDir, buttonRadius);
                moveAnalog.position = new Vector3(pos.x, pos.y, moveAnalog.position.z);
            }
        }

        if (Input.GetButtonUp("Fire1"))
        {
            moveAnalog.position = moveButton.position;
            EventSystem.current.SetSelectedGameObject(null);
        }
        //}
#endif
    }

    void Update()
    {
        //touch
        int touchCount = Input.touchCount;
        for(int touchIndex = 0; touchIndex < touchCount; touchIndex++)
        {
            int fingerID = Input.GetTouch(touchIndex).fingerId;
            
            if(Input.GetTouch(touchIndex).phase == TouchPhase.Began)
            {
                text.text = "began";
                UIElement[fingerID] = EventSystem.current.currentSelectedGameObject;
            }

            if(UIElement[fingerID] != null)
            {
                Vector2 pos = Input.GetTouch(touchIndex).position;

                Vector2 moveDir = pos - new Vector2(UIElement[fingerID].transform.position.x, UIElement[fingerID].transform.position.y);
                Vector3 worldMoveDir = new Vector3(moveDir.x, player.transform.position.y, moveDir.y);
                Vector3 normalizedWorldMoveDir = worldMoveDir.normalized;
                normalizedWorldMoveDir.y = 0.0f;

                direction[fingerID] = normalizedWorldMoveDir;

                pos = UIElement[fingerID].transform.position + Vector3.ClampMagnitude(moveDir, buttonRadius);
                UIElement[fingerID].transform.GetChild(0).position = new Vector3(pos.x, pos.y, UIElement[fingerID].transform.GetChild(0).position.z);
           
                /*if (UIElement[fingerID] == moveButton.gameObject)
                {
                    playerRigidbody.MovePosition(player.transform.position + normalizedWorldMoveDir * Time.deltaTime * speed);
                }
                else if (UIElement[fingerID] == lookButton.gameObject)
                {
                    player.transform.forward = normalizedWorldMoveDir;
                }*/
            }

            if (Input.GetTouch(touchIndex).phase == TouchPhase.Ended)
            {
                text.text = "ended";
                UIElement[fingerID].transform.GetChild(0).position = UIElement[fingerID].transform.position;

                UIElement[fingerID] = null;
                direction[fingerID] = Vector3.zero;
            }
        }
    }
}