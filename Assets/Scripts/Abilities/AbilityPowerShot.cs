using System;
using Controllers;
using UnityEngine;
using UnityEngine.Serialization;

namespace Abilities
{
    [CreateAssetMenu(menuName = "Abilities/PowerShot")]
    public class AbilityPowerShot : Ability
    {
        [SerializeField]
        private float power = 1.2f;

        public override void Activate(AbilityController abilityController)
        {
            GameObject abilityControllerGameObject = abilityController.gameObject;
            
            abilityControllerGameObject.AddComponent<PowerShotHandler>().ability = this;
        }

        public override void DoUpdate(AbilityController abilityController)
        {
        }

        public override void Deactivate(AbilityController abilityController)
        {
        }

        public class PowerShotHandler : MonoBehaviour
        {
            
            public AbilityPowerShot ability;
            
            private void OnCollisionEnter(Collision collision)
            {
                GameObject other = collision.gameObject;
                String thisTag = tag, otherTag = other.tag;

                if (thisTag == "Paddle" && otherTag == "Ball")
                    ApplyPowerShot(other);
                else if (thisTag == "Ball" && otherTag == "Paddle")
                    RemovePowerShot(other);

            }

            // PowerShotCollision in on paddle
            private void ApplyPowerShot(GameObject ball)
            {
                BallController ballController = ball.GetComponent<BallController>();
                ballController.speedMultiplier *= ability.power;

                ball.AddComponent<PowerShotHandler>().ability = ability;
                Destroy(this);
            }

            // PowerShotCollision is on ball
            private void RemovePowerShot(GameObject paddle)
            {
                GetComponent<BallController>().speedMultiplier /= ability.power;
                Destroy(this);
            }
        }
    }
}