using System.Collections;

namespace TheCreators.Player
{
    public abstract class State
    {
        public virtual IEnumerator Start()
        {
            yield break;
        }
        public virtual IEnumerator Run()
        {
            yield break;
        }
        public virtual IEnumerator Attack()
        {
            yield break;
        }
    }
}
