using UnityEngine;
using System.Collections;

public class LaserController : MonoBehaviour
{
    public GameObject laserDot;

    private GameObject player;
    private LineRenderer shootLine;

    private bool laserStatus;
    private bool firstSwitch;

    void Start()
    {
        shootLine = GetComponent<LineRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        laserStatus = false;
        firstSwitch = false;
}


    public void LaserStatus()
    {
        laserStatus = !laserStatus;
        if(laserStatus)
        {
            if (!firstSwitch)
            {
                laserDot = Instantiate(laserDot, Vector3.zero, Quaternion.identity) as GameObject;
                firstSwitch = true;
            }
            laserDot.SetActive(true);
        }
        else
        {
            laserDot.SetActive(false);
        }
    }


    void Update()
    {
        if (laserStatus == true)
        {
            StopCoroutine("SwitchLaser");
            StartCoroutine("SwitchLaser");
        }
    }


    IEnumerator SwitchLaser()
    {
        shootLine.enabled = true;

        while (laserStatus == true)
            {
            Ray laserRay = new Ray(this.transform.position, player.transform.forward);
            RaycastHit hit;

            shootLine.SetPosition(0, laserRay.origin);

            if (Physics.Raycast(laserRay, out hit, 300.0f))
            {
                //shootLine.SetPosition(1, (hit.point + laserRay.origin) / 2);
                //shootLine.SetPosition(2, hit.point);

                shootLine.SetPosition(1, hit.point);

                Quaternion hitObjectRotation = Quaternion.LookRotation(hit.normal);
                laserDot.transform.position = hit.point + hit.normal / 10.0f;
                laserDot.transform.rotation = hitObjectRotation;
                laserDot.transform.Rotate(90.0f, 00.0f, 0.0f);
            }

            yield return null;
        }

        shootLine.enabled = false;
    }
}
