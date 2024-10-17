using System;

namespace RTSSkill
{
    public class DeployerConfigFactory//反射来实现
    {
        public static ISkillSelector CreateSkillSelector(SkillData data)//范围选择算法 
        {
            string className = $"RTSSkillSystem.{data.selectorType}SkillSelector";
            return CreateObject<ISkillSelector>(className);
        }

        public static IImpactEffect[] CreateImpactEffects(SkillData data) //效果算法
        {
            IImpactEffect[] impacts = new IImpactEffect[data.impactType.Length];
            for (int i = 0; i < data.impactType.Length; i++)
            {
                string classname = $"RTSSkillSystem.{data.impactType[i]}Impact";
                impacts[i] = CreateObject<IImpactEffect>(classname);
            }
            return impacts;
        }

        private static T CreateObject<T>(string className) where T : class//创建对应算法
        {
            Type type = Type.GetType(className);
            return Activator.CreateInstance(type) as T;
        }
    }
}