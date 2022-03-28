using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MicrogameInternal {
    /// <summary>
    /// Classe Singleton base para o funcionamento do microgame
    /// não deverá ser alterada em sua entrega.
    /// </summary>
    public class GameManager {
        
        #region Instance Region
        private readonly Canvas _countdownUI;

        private int _lifes = 3;
        
        private List<int> _presentedGames;
        private int _gameCount;
        private int _gameCountToNextLevel;
        private const int _maxGameCount = 5;

        private readonly float[] _timeProgression  = {10.0f, 8.0f, 6.0f, 4.0f, 2.0f, 1.0f}; 
        private int _activeLevel;
        
        private float _startTime;
        public float RunningTime;

        // public bool debugMode = false;
        public float MaxTime => _timeProgression[_activeLevel];

        public float StartTime {
            get => _startTime;
            private set => _startTime = value;
        }

        private GameManager() {
            _countdownUI = Resources.Load<Canvas>("countdownUI");
            _presentedGames = new List<int>();
            _gameCount = 0;
            _gameCountToNextLevel = 5;
            _activeLevel = 0;
        }

        private void ResetSceneList() {
            _presentedGames.Clear();
        }

        private void LevelProgession() {
            _gameCount++;
            _gameCountToNextLevel--;
            if (_gameCountToNextLevel == 0) {
                _activeLevel++;
                _gameCountToNextLevel = _maxGameCount;
            }
        }
        #endregion
        
        #region Static Region
        private static GameManager _instance;
        public static GameManager GetInstance() {
            if (_instance == null) {
                _instance = new GameManager();
            }

            return _instance;
        }
        #endregion
        
        
        #region PublicAPI
        /// <summary>
        /// Esta função deverá ser chamada assim que seu jogo tiver sido carregado para que se inicie a contagem de tempo.
        /// </summary>
        public void StartTimer() {
            StartTime = Time.time;
            Object.Instantiate(_countdownUI);
        }
        
        /// <summary>
        /// Essa função NÃO deverá ser utilizada diretamente pelo seu código. Ao finalizar o timer, ela será executada
        /// automaticamente. 
        /// </summary>
        public void NextGame() {
            LevelProgession();
            int nextScene;
            int maxTries = 5;
            int tryCount = 0;
            do {
                nextScene = Random.Range(1, SceneManager.sceneCountInBuildSettings+1);
                Debug.Log(nextScene);

            } while (_presentedGames.Contains(nextScene) && tryCount++ < maxTries);
            _presentedGames.Add(nextScene);
            SceneManager.LoadScene(nextScene);
        }

        /// <summary>
        /// Esse função deverá ser executada assim que o seu jogo for considerado perdido. O comportamento padrão é
        /// considerar o jogo como "Vencido" até que se diga o contrário.
        /// </summary>
        public void GameLost() {
            _lifes--;
            if (_lifes > 0) NextGame();
            else SceneManager.LoadScene(0);
        }
        #endregion
    }
}