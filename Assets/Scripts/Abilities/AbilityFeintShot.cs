using System.Collections;
using Controllers;
using Managers;
using UnityEngine;

namespace Abilities
{
    [CreateAssetMenu(menuName = "Abilities/FeintShot")]
    public class AbilityFeintShot : Ability
    {

        [SerializeField]
        private float duration;
        
        public override void Activate(AbilityController abilityController)
        {
            abilityController.AddAbility(this);
            // abilityController.StopCoroutine(DeactivateInSeconds(duration, abilityController)); TODO
            abilityController.StartCoroutine(DeactivateInSeconds(duration, abilityController));
        }

        public override void DoUpdate(AbilityController abilityController)
        {
            // Guard Clause: continue only when space pressed
            if (!Input.GetKeyDown(KeyCode.Space))
                return;
            
            // Flip direction on the Z-axis
            BallController ball = GameManager.Instance.BallController;
            Vector3 dir = ball.Direction;
            ball.Direction = new Vector3(dir.x, dir.y, -dir.z);

            // Stop ability
            abilityController.StopCoroutine(DeactivateInSeconds(0f, abilityController));
            Deactivate(abilityController);
        }

        private IEnumerator DeactivateInSeconds(float seconds, AbilityController abilityController)
        {
            yield return new WaitForSeconds(seconds);
            Deactivate(abilityController);
        }

        public override void Deactivate(AbilityController abilityController)
        {
            abilityController.RemoveAbility(this);
        }
    }
}