using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AnimalsDemo
{
    public enum ScreenType
    {
        Main,
        Setup,
    }

    public class ScreenController : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> screensObjects;

        private List<IScreen> screens;

        private void Awake()
        {
            screens = screensObjects.Select(it => it.GetComponent<IScreen>()).ToList();
        }

        public void SetScreen(ScreenType type)
        {
            foreach (var screen in screens)
            {
                if (screen.ScreenType == type)
                {
                    screen.Show();
                }
                else
                {
                    screen.Hide();
                }
            }
        }
    }
}
