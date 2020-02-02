using UnityEngine;

namespace Skill
{
    public class RadiationTherapy : ISkill
    {
        public string Name => "RadiationTherapy";
        public float CoolDownTime => 30;
        public float CoolDownTimeRemain { get; set; }
        private const float VirusDamage = 20;
        private const float AntiDamage = 20;
        private const float Damage = 10;
        public bool active { get; set; }

        public void Start()
        {
            var targetArr = GameObject.FindGameObjectsWithTag("virus");
            foreach (var gameObject in targetArr)
            {
                gameObject.GetComponent<Cell>().health -= VirusDamage;
            }

            targetArr = GameObject.FindGameObjectsWithTag("anti");
            foreach (var gameObject in targetArr)
            {
                gameObject.GetComponent<Cell>().health -= AntiDamage;
            }

            GameManager.GM.hp -= Damage;
        }
    }
}