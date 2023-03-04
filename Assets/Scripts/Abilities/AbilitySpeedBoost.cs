using System.Collections;
using Controllers;
using UnityEngine;
using UnityEngine.Serialization;

namespace Abilities
{
    [CreateAssetMenu(menuName = "Abilities/SpeedBoost")]
    public class AbilitySpeedBoost : Ability
    {

        [SerializeField]
        private float amount = 1.2f;

        [SerializeField]
        private float duration = 2f;
        
        public override void Activate(AbilityController abilityController)
        {
            PlayerController playerController = abilityController.GetComponent<PlayerController>();
            if (playerController == null)
                return;

            playerController.speedMultiplier *= amount;
            abilityController.StartCoroutine(DeactivateInSeconds(duration, abilityController));
        }

        public override void DoUpdate(AbilityController abilityController)
        {
            
        }

        // Performance disabled because Rider thinks I'm gonna call the GetComponent<>
        // method multiple times inside the coroutine, but it's just one time
        private IEnumerator DeactivateInSeconds(float seconds, AbilityController abilityController)
        {
            yield return new WaitForSeconds(seconds);
            // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
            Deactivate(abilityController);
        }

        public override void Deactivate(AbilityController abilityController)
        {
            // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
            abilityController.GetComponent<PlayerController>().speedMultiplier /= amount;
        }
    }
}