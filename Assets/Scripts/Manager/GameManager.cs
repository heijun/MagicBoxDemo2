using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class GameManager : MonoBehaviour
{
    public Texture2D cursorTexture;
    /// <summary>
    /// ����ֻ����ʾ��һ��ʼ���ų������TimeLine���������ڿ�ɾ
    /// </summary>
    //private PlayableDirector director = null;
    // Start is called before the first frame update
    void Start()
    {
        //director = GetComponent<PlayableDirector>();

        //director.Play();
    }

    // Update is called once per frame
    void Update()
    {

        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    }
}
