using UnityEngine;

namespace SimpleBehaviours
{
    public class FixedMovement : MonoBehaviour
    {

        [SerializeField]
        private Vector3 speed;

        public Vector3 Speed
        {
            get => speed;
            set => speed = value;
        }

        // Update is called once per frame
        private void Update()
        {
            transform.Translate(Time.deltaTime * speed);
        }
    }
}
