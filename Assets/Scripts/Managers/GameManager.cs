using Controllers;
using UnityEngine;
using Utils;

namespace Managers
{
    public class GameManager : Singleton<GameManager>
    {

        public GameObject Ball => ball;
        public GameObject LeftPlayer => leftPlayer;
        public GameObject RightPlayer => rightPlayer;

        public BallController BallController { get; private set; }
        public PlayerController LeftPlayerController { get; private set; }
        public PlayerController RightPlayerController { get; private set; }

        [SerializeField]
        private GameObject ball;

        // Left Player
        [SerializeField]
        private GameObject leftPlayer;

        // Right Player
        [SerializeField]
        private GameObject rightPlayer;

        protected override void Awake()
        {
            base.Awake();
            BallController = ball.GetComponent<BallController>();
            LeftPlayerController = leftPlayer.GetComponent<PlayerController>();
            RightPlayerController = rightPlayer.GetComponent<PlayerController>();
        }
        
    }
}