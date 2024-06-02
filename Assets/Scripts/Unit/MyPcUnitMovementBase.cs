using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPcUnitMovementBase : UnitMovementBase
{
    void Start()
    {
        GameControl.aInstance.mOnMoving += HandleMoving;
        GameControl.aInstance.mOnMoveStart += HandleMoveStart;
        GameControl.aInstance.mOnMoveEnd += HandleMoveEnd;
    }

    void OnDestroy()
    {
        GameControl.aInstance.mOnMoving -= HandleMoving;
        GameControl.aInstance.mOnMoveStart -= HandleMoveStart;
        GameControl.aInstance.mOnMoveEnd -= HandleMoveEnd;
    }

    private void HandleMoving(Vector3 pDirect)
    {
        transform.position += pDirect * mSpeed * Time.deltaTime;
        mRotationTransform.rotation = Quaternion.RotateTowards(mRotationTransform.rotation, 
            Quaternion.LookRotation(pDirect), mRotationSpeed * Time.deltaTime);

    }

    private void HandleMoveStart()
    {
        if (mAnimator != null)
        {
            mAnimator.CrossFade("RUN", 0.1f);
        }
    }

    private void HandleMoveEnd()
    {
        if (mAnimator != null)
        {
            mAnimator.CrossFade("IDLE", 0.1f);
        }
    }
}
