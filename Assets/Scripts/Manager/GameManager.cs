using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int mStateId = 1;
    public GameObject mMyPc;
    public Transform mNpcSpawnParent;
    public Transform mSkillObjectParent;
    public Transform mItemObjectParent;

    void Start()
    {
        GameDataManager.aInstance.Init();
        GameDataManager.aInstance.SetStageData(mMyPc, mNpcSpawnParent, mSkillObjectParent, mItemObjectParent);
        GameDataManager.aInstance.SetCurrentStatge(mStateId);

        GamePoolManager.aInstance.Init();

        GameControl.aInstance.Init();
        GameControl.aInstance.SetControlObject(mMyPc);

        SpawnManager.aInstance.Init();
        FSMStageController.aInstance.Init();

        FSMStageController.aInstance.EnterStage();
    }

    private void OnDestroy()
    {
        GamePoolManager.aInstance.Clear();
        GameControl.aInstance.Clear();
        SpawnManager.aInstance.Clear();
        GameDataManager.aInstance.Clear();
        FSMStageController.aInstance.Clear();
    }

    void Update()
    {
        FSMStageController.aInstance.OnUpdate(Time.deltaTime);
        GameControl.aInstance.OnUpdate();
    }

    private void FixedUpdate()
    {
        
    }

    private void LateUpdate()
    {
        
    }
}
