using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class Swipe : MonoBehaviour
{
    //public Text debugtext;

    public GameObject sorp;
    public GameObject obj;
    public GameObject cam;

    public float speed = 0;

    // �X���C�v�ŏ��ړ�����
    [SerializeField]
    private Vector2 SwipeMinRange = new Vector2(50.0f, 50.0f);
    // TAP��NONE�ɖ߂��܂ł̃J�E���g
    [SerializeField]
    private int NoneCountMax = 2;
    private int NoneCountNow = 0;
    // �X���C�v���͋���
    private Vector2 SwipeRange;
    // ���͕����L�^�p
    private Vector2 InputSTART;
    private Vector2 InputMOVE;
    private Vector2 InputEND;
    // �X���C�v�̕���
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
        //debugtext.text = "nowswipe" + NowSwipe + "\n�^�b�v���W" + Input.mousePosition.x;

        GetInputVector();
        trans();
    }

    // ���͂̎擾
    private void GetInputVector()
    {
        // Unity��ł̑���擾
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
        // �[����ł̑���擾
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

    // ���͓��e����X���C�v�������v�Z
    private void SwipeCLC()
    {
        SwipeRange = new Vector2((new Vector3(InputMOVE.x, 0, 0) - new Vector3(InputSTART.x, 0, 0)).magnitude, (new Vector3(0, InputMOVE.y, 0) - new Vector3(0, InputSTART.y, 0)).magnitude);

        if (/*SwipeRange.x <= SwipeMinRange.x && */SwipeRange.y <= SwipeMinRange.y)
        {
            NowSwipe = SwipeDirection.TAP;
        }
        /*else if (SwipeRange.x > SwipeRange.y)
        {
            float _x = Mathf.Sign(InputMOVE.x - InputSTART.x);
            if (_x > 0) NowSwipe = SwipeDirection.RIGHT;
            else if (_x < 0) NowSwipe = SwipeDirection.LEFT;
        }*/
        else
        {
            float _y = Mathf.Sign(InputMOVE.y - InputSTART.y);
            if (_y > 0) NowSwipe = SwipeDirection.UP;
            else if (_y < 0) NowSwipe = SwipeDirection.DOWN;
            float _angle = Mathf.Atan2(InputEND.y - InputSTART.y, InputEND.x - InputSTART.x) * Mathf.Rad2Deg;
            //if (-22.5f <= _angle && _angle < 22.5f) NowSwipe = SwipeDirection.RIGHT;
            //else if (67.5f <= _angle && _angle < 112.5f) NowSwipe = SwipeDirection.UP;
            //else if (157.5f <= _angle || _angle < -157.5f) NowSwipe = SwipeDirection.LEFT;
            //else if (-112.5f <= _angle && _angle < -67.5f) NowSwipe = SwipeDirection.DOWN;
        }
    }

    // NONE�Ƀ��Z�b�g
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
    // �X���C�v�����̎擾
    public SwipeDirection GetNowSwipe()
    {
        return NowSwipe;
    }

    // �X���C�v�ʂ̎擾
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

    // �X���C�v�ʂ̎擾
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
        if(Input.mousePosition.x <= Screen.width / 2 && NowSwipe == SwipeDirection.UP/* && GetSwipeRange() >= 1*/)
        {
            speed = 1;
            Vector3 velocity = cam.transform.rotation * new Vector3(0, 0, speed);
            obj.transform.position += velocity * Time.deltaTime;
        }else if(/*Input.mousePosition.x <= Screen.width / 2 && */NowSwipe == SwipeDirection.UP/* && GetSwipeRange() >= 1 */&& Input.touchCount >= 2)
        {
            speed = 1;
            Vector3 velocity = cam.transform.rotation * new Vector3(0, 0, speed);
            obj.transform.position += velocity * Time.deltaTime;
        }


        if(Input.mousePosition.x <= Screen.width / 2 && NowSwipe == SwipeDirection.DOWN/* && GetSwipeRange() >= 1*/)
        {
            speed = -1;
            Vector3 velocity = cam.transform.rotation * new Vector3(0, 0, speed);
            obj.transform.position += velocity * Time.deltaTime;
        }else if(/*Input.mousePosition.x <= Screen.width / 2 && */NowSwipe == SwipeDirection.DOWN/* && GetSwipeRange() >= 1 */&& Input.touchCount >= 2)
        {
            speed = -1;
            Vector3 velocity = cam.transform.rotation * new Vector3(0, 0, speed);
            obj.transform.position += velocity * Time.deltaTime;
        }
    }
}