using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePoolManager
{

    public static GamePoolManager aInstance
    {
        get
        {
            if (sInstance == null)
            {
                sInstance = new GamePoolManager();
            }

            return sInstance;
        }
    }

    public void Init()
    {
        SkillPool = new Dictionary<SkillType, Queue<SkillBase>>();
    }

    public void Clear()
    {
        SkillPool.Clear();
        SkillPool = null;
    }

    public void EnqueueSkillPool(SkillBase inSkill)
    {
        if (SkillPool == null)
        {
            return;
        }

        if (SkillPool.ContainsKey(inSkill.mSkillType) == false)
        {
            SkillPool.Add(inSkill.mSkillType, new Queue<SkillBase>());
        }

        SkillPool[inSkill.mSkillType].Enqueue(inSkill);
    }

    public SkillBase DequeueSkillPool(SkillType inSkillType)
    {
        if (SkillPool == null)
        {
            return null;
        }

        if (SkillPool.ContainsKey(inSkillType) == false)
        {
            return null;
        }

        return SkillPool[inSkillType].Dequeue();
    }

    private static GamePoolManager sInstance = null;
    private Dictionary<SkillType, Queue<SkillBase>> SkillPool = null;
}
