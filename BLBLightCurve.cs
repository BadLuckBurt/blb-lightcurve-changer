using UnityEngine;
using DaggerfallWorkshop.Game;

namespace BLB.LightCurve 
{
    public class BLBLightCurve : MonoBehaviour
    {
        public AnimationCurve myLightCurve;

        void Start()
        {
            SunlightManager sunlightManager = GameManager.Instance.SunlightManager;
            sunlightManager.LightCurve = myLightCurve;
            Debug.Log("Changed Light Curve");
        }
    }
}