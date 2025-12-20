using UnityEngine;

namespace CustomerStuff
{
    public class Customer : MonoBehaviour
    {
        [SerializeField] private CustomerExpressionSetter _expressionSetter;
        [SerializeField] private CustomerMover _mover;

        private Color _wantedColor;

        public Color WantedColor => _wantedColor;

        private void OnDisable()
        {
            _mover.SetOnSpot -= _expressionSetter.MakeExpression;
        }

        public void SetSound(AudioSource sound)
        {
            _expressionSetter.SetSound(sound);
            _mover.SetOnSpot += _expressionSetter.MakeExpression;
        }

        public void SetWantedColor(Color color)
        {
            _wantedColor = color;
        }

        public void SetPosition(Vector3 position)
        {
            _mover.SetPosition(position);
        }

        public void GoToPosition()
        {
            Coroutine coroutine = StartCoroutine(_mover.Move());
        }

        public void OnLose()
        {
            _expressionSetter.OnLose();
        }

        public void OnWin()
        {
            _expressionSetter.OnWin();
        }
    }
}