using UnityEngine;
using GameKit.Managers;

namespace GameKit.Managers
{
    public abstract class SharedManager : MonoBehaviour
    {
        /// <summary>
        /// Init manager's internal state.
        /// </summary>
        public abstract void InitManager();

        /// <summary>
        /// Call on application pause or exit.
        /// </summary>
        public abstract void OnAppDeactivate();
    }

    public abstract class SharedManager<TS> : SharedManager where TS : SharedManager
    {
        const string LOG_KEY = "SHARED_MANAGER";

        static TS instance;

        public override void InitManager()
        {
            instance = this as TS;
            Debug.Log("Meow");
        }

        public override void OnAppDeactivate()
        {
        }

        public static TS Instance => instance;
    }
}

