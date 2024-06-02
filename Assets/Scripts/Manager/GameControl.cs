using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl
{
    public delegate void OnMoving(Vector3 pDirect);
    public delegate void OnMoveStart();
    public delegate void OnMoveEnd();

    public OnMoving mOnMoving { get; set; }
    public OnMoveStart mOnMoveStart { get; set; }

    public OnMoveStart mOnMoveEnd { get; set; }


    public static GameControl aInstance
    {
        get
        {
            if (sInstance == null)
            {
                sInstance = new GameControl();
            }

            return sInstance;
        }
    }

    public void Init()
    {

    }

    public void SetControlObject(GameObject inGameObject)
    {
        mControlObject = inGameObject;
        mMovementBase = inGameObject.GetComponent<UnitMovementBase>();
    }

    public GameObject GetControlObject() 
    {
        return mControlObject;
    }

    public void OnUpdate()
    {
        _UpdateKeybord();
    }

    public void Clear()
    {

    }

    private void _UpdateKeybord()
    {
        Vector3 MoveVector = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            MoveVector += new Vector3(0, 0, 1);
        }

        if (Input.GetKey(KeyCode.A))
        {
            MoveVector += new Vector3(-1, 0, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            MoveVector += new Vector3(0, 0, -1);
        }

        if (Input.GetKey(KeyCode.D))
        {
            MoveVector += new Vector3(1, 0, 0);
        }

        Vector3 MoveVectorNormal = MoveVector.normalized;

        if (MoveVectorNormal != Vector3.zero)
        {
            if (mOnMoving != null)
            {
                mOnMoving(MoveVectorNormal);
            }
            if (mIsMoving == false)
            {
                if (mOnMoveStart != null)
                {
                    mOnMoveStart();
                }

                mIsMoving = true;
            }
        }
        else
        {
            if (mIsMoving == true)
            {
                if (mOnMoving != null)
                {
                    mOnMoveEnd();
                }
                mIsMoving = false;
            }
        }
    }

    private static GameControl sInstance = null;

    private GameObject mControlObject = null;
    private UnitMovementBase mMovementBase = null;
    private bool mIsMoving = false;
}
