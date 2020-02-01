namespace Skill
{
    public class CoolDown : ISkill
    {
        public string Name => "CoolDown";
        public float CoolDownTime => 40;
        public float CoolDownTimeRemain { get; set; }
        private const float RecoverHp = 5;
        public void Start()
        {
            GameManager.GM.hp += RecoverHp;
        }
    }
}