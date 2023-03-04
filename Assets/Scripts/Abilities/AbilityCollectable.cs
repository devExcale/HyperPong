using System;
using Controllers;
using UnityEngine;

namespace Abilities
{
    public class AbilityCollectable : MonoBehaviour
    {

        [SerializeField]
        private Ability ability;

        private void OnTriggerEnter(Collider other)
        {
            AbilityController controller = other.GetComponent<AbilityController>();
            
            // Guard Clause: continue only when other has AbilityController
            if (controller == null)
                return;

            ability.Activate(controller);
            Destroy(gameObject);
        }
    }
}