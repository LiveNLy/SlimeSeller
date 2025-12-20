using UnityEngine;

namespace CustomerStuff
{
    public class CustomerExpressionSetter : MonoBehaviour
    {
        private Animator _animator;
        private AudioSource _sound;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void SetSound(AudioSource sound)
        {
            _sound = sound;
            _sound.pitch = Random.Range(1f, 1.6f);
        }

        public void OnLose()
        {
            _animator.SetBool("OnLose", true);
        }

        public void OnWin()
        {
            _animator.SetBool("OnWin", true);
        }

        public void MakeExpression()
        {
            _animator.SetBool("OnSpot", true);
            _sound.Play();
        }
    }
}