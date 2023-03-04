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

        [SerializeField]
        private GameObject ball;

        // Left Player
        [SerializeField]
        private GameObject leftPlayer;

        // Right Player
        [SerializeField]
        private GameObject rightPlayer;

    }
}