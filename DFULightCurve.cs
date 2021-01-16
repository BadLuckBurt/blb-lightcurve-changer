using System;
using UnityEngine;
using DaggerfallWorkshop.Game;
using DaggerfallWorkshop.Game.Utility.ModSupport;
using DaggerfallWorkshop.Utility.AssetInjection;
using DaggerfallWorkshop.Game.UserInterface;
using DaggerfallWorkshop.Game.UserInterfaceWindows;
using DaggerfallWorkshop.Game.Items;
using DaggerfallWorkshop.Utility;
using DaggerfallWorkshop;
using DaggerfallWorkshop.Game.Serialization;
using DaggerfallConnect.Utility;

namespace BLB.LightCurve 
{
    public class DFULightCurveLoader : MonoBehaviour 
    {
        public static Mod mod;
    //like in the last example, this is used to setup the Mod.  This gets called at Start state.
        [Invoke(StateManager.StateTypes.Start, 0)]
        public static void Init(InitParams initParams)
        {
            mod = initParams.Mod;
            Debug.Log("Started setup of : " + mod.Title);
            new GameObject("DFULightCurveLoader").AddComponent<DFULightCurveLoader>(); // Add script to the scene.    
            AnimationCurve curve = new AnimationCurve(
                new Keyframe(0.0f, 0.0f), 
                new Keyframe(0.075f, 0.25f),
                new Keyframe(0.5f, 0.4f),
                new Keyframe(0.915f, 0.25f),
                new Keyframe(1.0f, 0.0f)
            );
            curve.postWrapMode = WrapMode.ClampForever;
            curve.preWrapMode = WrapMode.ClampForever;
            SunlightManager sunlightManager = GameManager.Instance.SunlightManager;
            sunlightManager.LightCurve = curve;
            Debug.Log("Changed Light Curve");

            mod.IsReady = true;
        }
    }
}