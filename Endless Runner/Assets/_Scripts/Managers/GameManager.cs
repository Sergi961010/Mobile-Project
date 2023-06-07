using UnityEngine;

namespace TheCreators.Managers
{
    public class GameManager : MonoBehaviour
    {
        #region Singleton
        private static GameManager _instance;

        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<GameManager>();
                }
                return _instance;
            }
        }
        #endregion

        public Vector2 GameVelocity;
        private const float MAX_GAME_X_VELOCITY = 5f;
        public float GameAcceleration;
        public float MaxGameAcceleration;
        private void Awake()
        {
            #region Singleton
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
            }
            #endregion

            MaxGameAcceleration = 0.5f;
        }

        private void Update()
        {
            float gameVelocityRatio = GameVelocity.x / MAX_GAME_X_VELOCITY;
            GameAcceleration = MaxGameAcceleration * (1 - gameVelocityRatio);
            GameVelocity.x += GameAcceleration * Time.deltaTime;
            if (GameVelocity.x >= MAX_GAME_X_VELOCITY)
            {
                GameVelocity.x = MAX_GAME_X_VELOCITY;
            }
        }
    }
}
