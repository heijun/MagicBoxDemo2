using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class FindPlayer : MonoBehaviour
{
    public GameObject Player;
    public GameObject Parent;
    GameObject Cam;
    private void Awake()
    {
        Parent = GameObject.FindGameObjectWithTag("magic");
        Player = GameObject.FindGameObjectWithTag("player");
        Cam = GameObject.Find("CM vcam1");
        Player.transform.position = Vector3.zero;

    }
    public void SetPositon() {
        Player.transform.SetParent(Parent.transform);
        Player.transform.position = GameObject.Find("³öÉúµã").transform.position;
        if (SceneManager.GetActiveScene().name == "level2")
        {
            Player.transform.localEulerAngles = new Vector3(0, 90, 90);
        }
        else {
            Player.transform.localEulerAngles = new Vector3(0, 0, 0);
        }

        Cam.GetComponent<CinemachineVirtualCamera>().Follow = Player.transform;
        Cam.GetComponent<CinemachineVirtualCamera>().LookAt= Player.transform;
    }
    // Start is called before the first frame update
    void Start()
    {
  
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
