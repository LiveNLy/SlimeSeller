using Interfaces;

namespace Buffs
{
    public class Respawn : BuffClick
    {
        private ITool _spawner;

        public override void ApplyEffect()
        {
            _spawner.ApplyEffect(0);
        }

        public override void SetTool(ITool spawner)
        {
            _spawner = spawner;
        }
    }
}