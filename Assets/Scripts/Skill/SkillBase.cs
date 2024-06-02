using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBase : MonoBehaviour
{
    public SkillType mSkillType { set; get; }

    public virtual void FireSkill(Vector3 inStartPos, Vector3 inStartDir)
    {

    }

    public virtual void StopSkill()
    {
        gameObject.SetActive(false);
        GamePoolManager.aInstance.EnqueueSkillPool(this);
    }

    public virtual void Update()
    {
        
    }

    public virtual void OnDestroy()
    {

    }

}
