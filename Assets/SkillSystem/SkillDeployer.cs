using UnityEngine;

namespace RTSSkill
{
    //技能释放器
    public abstract class SkillDeployer : MonoBehaviour
    {
        private SkillData skillData;
        public SkillData SkillData //技能管理器提供
        {
            get { return skillData; }
            set { skillData = value; InitDeplopyer(); }
        }

        //范围选择算法
        private ISkillSelector selector;

        //效果算法对象 
        private IImpactEffect[] impactArray;

        //初始化释放器
        private void InitDeplopyer()
        {
            //范围选择
            selector = DeployerConfigFactory.CreateSkillSelector(skillData);
            //效果
            impactArray = DeployerConfigFactory.CreateImpactEffects(skillData);
        }

        //范围选择
        public void CalculateTargets()
        {
            skillData.attackTargets = selector.SelectTarget(skillData, this.transform);
        }

        //效果
        public void ImpactTargets()
        {
            for (int i = 0; i < impactArray.Length; i++)
            {
                impactArray[i].Execute(this);
            }
        }

        public abstract void DeploySkill();//供技能管理器调用，由子类实现，定义具体释放策略
    }
}