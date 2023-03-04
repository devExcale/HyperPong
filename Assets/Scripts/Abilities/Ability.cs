using Controllers;
using UnityEngine;

namespace Abilities
{
    public abstract class Ability : ScriptableObject
    {

        public abstract void Activate(AbilityController abilityController);

        public abstract void DoUpdate(AbilityController abilityController);

        public abstract void Deactivate(AbilityController abilityController);

    }
}