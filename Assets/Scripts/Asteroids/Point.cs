using Astroboy.ScoreSystem;
using UnityEngine;
using UnityEngine.Events;

namespace Astroboy.Asteroid
{
    public class Point : MonoBehaviour
    {
        [SerializeField]
        private int pointValue = 1;

        public delegate void UpdatePoint();
        public static event UpdatePoint OnUpdatePoint;

        #region Properties
        private static int _actualPointCount;

        public int GetActualPointCount
        {
            get => _actualPointCount;
        }

        #endregion

        public void AddPoint()
        {
            GetPoint();
        }

        private void GetPoint()
        {
            _actualPointCount++;
            Score.AddScore(pointValue);

            if (OnUpdatePoint != null)
                OnUpdatePoint();
        }
    }
}
