using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCtrl : MonoBehaviour
{
    public GameObject Cam;
    public GameObject ViewCamera;
    public bool flag;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            flag = !flag;

        }
        if (flag)
        {

            Cam.SetActive(true);
            ViewCamera.SetActive(false);
        }
        else {
            Cam.SetActive(false);
            ViewCamera.SetActive(true);

        }

    }
}
