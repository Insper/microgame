using UnityEngine;
using UnityEngine.UI;

namespace MicrogameInternal {
    public class CountdownTimer : MonoBehaviour {
        private Image _timerFill;
        private GameManager _gm;

        private void Start() {
            _gm = GameManager.GetInstance();
            _timerFill = GetComponentInChildren<Image>();
        }

        private void Update() {
            _gm.RunningTime = (_gm.MaxTime - (Time.time - _gm.StartTime));
            _timerFill.fillAmount = _gm.RunningTime / _gm.MaxTime;
            if (_gm.RunningTime < 0) {
                _gm.NextGame();
                Destroy(gameObject);
            }
        }
    }
}
