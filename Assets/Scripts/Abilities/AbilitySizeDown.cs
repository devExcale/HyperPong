using System.Collections;
using Controllers;
using Managers;
using UnityEngine;

namespace Abilities
{
    [CreateAssetMenu(menuName = "Abilities/SizeDown")]
    public class AbilitySizeDown : Ability
    {

        [SerializeField]
        private float scale = 1.2f;

        [SerializeField]
        private float duration = 2f;

        public override void Activate(AbilityController abilityController)
        {
            AbilityController opponent = GetOpponent(abilityController);
            
            // Scale down opponent instead of player that picks the ability
            Transform objTransform = opponent.gameObject.transform;
            Vector3 objScale = objTransform.localScale;
            objTransform.localScale = new Vector3(objScale.x, objScale.y, objScale.z / scale);
            
            opponent.StartCoroutine(DeactivateInSeconds(duration, opponent));
        }

        private static AbilityController GetOpponent(AbilityController abilityController)
        {
            GameManager gameManager = GameManager.Instance;
            GameObject leftPlayer = gameManager.LeftPlayer;
            GameObject rightPlayer = gameManager.RightPlayer;

            GameObject opponent = (abilityController.gameObject == leftPlayer) ? rightPlayer : leftPlayer;
            return opponent.GetComponent<AbilityController>();
        }

        public override void DoUpdate(AbilityController abilityController)
        {
        }

        private IEnumerator DeactivateInSeconds(float seconds, AbilityController abilityController)
        {
            yield return new WaitForSeconds(seconds);
            Deactivate(abilityController);
        }

        public override void Deactivate(AbilityController abilityController)
        {
            Transform objTransform = abilityController.gameObject.transform;
            Vector3 objScale = objTransform.localScale;
            objTransform.localScale = new Vector3(objScale.x, objScale.y, objScale.z * scale);
        }
    }
}