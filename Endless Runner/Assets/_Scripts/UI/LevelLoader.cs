using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TheCreators
{
    public class LevelLoader : MonoBehaviour
    {
        private Animator _animator;
        private readonly float _transitionTime = 1f;
        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
        }
        public void LoadScene(int sceneIndex)
        {
            StartCoroutine(LoadLevelCoroutine(sceneIndex));
        }
        private IEnumerator LoadLevelCoroutine(int sceneIndex)
        {
            _animator.SetTrigger("Start");
            yield return new WaitForSeconds(_transitionTime);
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
