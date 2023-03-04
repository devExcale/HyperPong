using System;
using System.Collections.Generic;
using Abilities;
using UnityEngine;

namespace Controllers
{
    public class AbilityController : MonoBehaviour
    {

        private readonly HashSet<Ability> _abilities = new HashSet<Ability>();

        private void Update()
        {
            foreach (Ability ability in _abilities)
                ability.DoUpdate(this);
        }

        public void AddAbility(Ability ability)
        {
            _abilities.Add(ability);
        }

        public void RemoveAbility(Ability ability)
        {
            _abilities.Remove(ability);
        }

        public bool HasAbility(Ability ability)
        {
            return _abilities.Contains(ability);
        }

    }
}