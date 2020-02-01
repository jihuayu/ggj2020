using UnityEngine;

namespace Skill
{
    public class Antibiotics : ISkill
    {
        public string Name => "Antibiotics";
        public float CoolDownTime => 50;
        public float CoolDownTimeRemain { get; set; }
        private const float Damage = 10;
        public void Start()
        {
            var targetArr = GameObject.FindGameObjectsWithTag("virus");
            foreach (var gameObject in targetArr)
            {
                gameObject.GetComponent<Cell>().health -= Damage;
            }
        }
    }
}