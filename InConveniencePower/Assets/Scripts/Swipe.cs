using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class Swipe : MonoBehaviour
{

    public GameObject sorp;
    public GameObject obj;
    public GameObject cam;

    public float speed = 0;

    // スワイプ最小移動距離
    [SerializeField]
    private Vector2 SwipeMinRange = new Vector2(50.0f, 50.0f);
    // TAPをNONEに戻すまでのカウント
    [SerializeField]
    private int NoneCountMax = 2;
    private int NoneCountNow = 0;
    // スワイプ入力距離
    private Vector2 SwipeRange;
    // 入力方向記録用
    private Vector2 InputSTART;
    private Vector2 InputMOVE;
    private Vector2 InputEND;
    // スワイプの方向
    public enum SwipeDirection
    {
        NONE,
        TAP,
        UP,
        DOWN,
    }
    private SwipeDirection NowSwipe = SwipeDirection.NONE;


    private void Start()
    {
        Application.targetFrameRate = 30;
    }

    // Update is called once per frame
    void Update()
    {

        GetInputVector();
        trans();
    }

    // 入力の取得
    private void GetInputVector()
    {
        // Unity上での操作取得
        if (Application.isEditor)
        {
            if (Input.GetMouseButtonDown(0))
            {
                InputSTART = Input.mousePosition;
            }
            else if (Input.GetMouseButton(0))
            {
                InputMOVE = Input.mousePosition;
                SwipeCLC();
            }
            else if ( NowSwipe != SwipeDirection.NONE)
            {
                ResetParameter();
            }
        }
        // 端末上での操作取得
        else
        {
            if (Input.touchCount >= 2)
            {
                Touch touch = Input.touches[1];
                if (touch.phase == TouchPhase.Began)
                {
                    InputSTART = touch.position;
                }
                else if (touch.phase == TouchPhase.Moved)
                {
                    InputMOVE = touch.position;
                    SwipeCLC();
                }
            }
            else if ( NowSwipe != SwipeDirection.NONE)
            {
                ResetParameter();
            }
        }
    }

    // 入力内容からスワイプ方向を計算
    private void SwipeCLC()
    {
        SwipeRange = new Vector2((new Vector3(InputMOVE.x, 0, 0) - new Vector3(InputSTART.x, 0, 0)).magnitude, (new Vector3(0, InputMOVE.y, 0) - new Vector3(0, InputSTART.y, 0)).magnitude);

        if (SwipeRange.y <= SwipeMinRange.y)
        {
            NowSwipe = SwipeDirection.TAP;
        }
        else
        {
            float _y = Mathf.Sign(InputMOVE.y - InputSTART.y);
            if (_y > 0) NowSwipe = SwipeDirection.UP;
            else if (_y < 0) NowSwipe = SwipeDirection.DOWN;
            float _angle = Mathf.Atan2(InputEND.y - InputSTART.y, InputEND.x - InputSTART.x) * Mathf.Rad2Deg;
        }
    }

    // NONEにリセット
    private void ResetParameter()
    {
        NoneCountNow++;
        if (NoneCountNow >= NoneCountMax)
        {
            NoneCountNow = 0;
            NowSwipe = SwipeDirection.NONE;
            SwipeRange = new Vector2(0, 0);
        }
    }
    // スワイプ方向の取得
    public SwipeDirection GetNowSwipe()
    {
        return NowSwipe;
    }

    // スワイプ量の取得
    public float GetSwipeRange()
    {
        if (SwipeRange.x > SwipeRange.y)
        {
            return SwipeRange.x;
        }
        else
        {
            return SwipeRange.y;
        }
    }

    // スワイプ量の取得
    public Vector2 GetSwipeRangeVec()
    {
        if (NowSwipe != SwipeDirection.NONE)
        {
            return new Vector2(InputMOVE.x - InputSTART.x, InputMOVE.y - InputSTART.y);
        }
        else
        {
            return new Vector2(0, 0);
        }
    }

    void trans()
    {
        if(Input.mousePosition.x <= Screen.width / 2 && NowSwipe == SwipeDirection.UP)
        {
            speed = 1;
            Vector3 velocity = cam.transform.rotation * new Vector3(0, 0, speed);
            obj.transform.position += velocity * Time.deltaTime;
        }else if(NowSwipe == SwipeDirection.UP && Input.touchCount >= 2)
        {
            speed = 1;
            Vector3 velocity = cam.transform.rotation * new Vector3(0, 0, speed);
            obj.transform.position += velocity * Time.deltaTime;
        }


        if(Input.mousePosition.x <= Screen.width / 2 && NowSwipe == SwipeDirection.DOWN)
        {
            speed = -1;
            Vector3 velocity = cam.transform.rotation * new Vector3(0, 0, speed);
            obj.transform.position += velocity * Time.deltaTime;
        }else if(NowSwipe == SwipeDirection.DOWN && Input.touchCount >= 2)
        {
            speed = -1;
            Vector3 velocity = cam.transform.rotation * new Vector3(0, 0, speed);
            obj.transform.position += velocity * Time.deltaTime;
        }
    }
}
