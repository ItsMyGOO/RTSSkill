using UnityEngine;

namespace RTSSkill
{
    public interface ISkillSelector //范围选择算法接口
    {
        Transform[] SelectTarget(SkillData data, Transform skillTF);//skillTF是技能预制体
    }
}