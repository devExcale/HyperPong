using System.Collections;
using Controllers;
using UnityEngine;

namespace Abilities
{
    [CreateAssetMenu(menuName = "Abilities/SizeUp")]
    public class AbilitySizeUp : Ability
    {

        [SerializeField]
        private float scale = 1.2f;

        [SerializeField]
        private float duration = 2f;
        
        public override void Activate(AbilityController abilityController)
        {
            Transform objTransform = abilityController.gameObject.transform;
            Vector3 objScale = objTransform.localScale;
            objTransform.localScale = new Vector3(objScale.x, objScale.y, objScale.z * scale);
            
            abilityController.StartCoroutine(DeactivateInSeconds(duration, abilityController));
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
            objTransform.localScale = new Vector3(objScale.x, objScale.y, objScale.z / scale);
        }
    }
}