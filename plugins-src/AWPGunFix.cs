using System;
using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;

namespace AWPGunFix
{
    /// <summary>AWP 专用：单发（每次按键只打一发）。只作用于名字含 AWP 的枪。</summary>
    [BepInPlugin("cn_xc.AWPGunFix", "AWP Gun Fix", "0.1.0")]
    public class Plugin : BaseUnityPlugin
    {
        internal static ManualLogSource Log;
        private static MethodInfo _toggleItem;
        private static MethodInfo _localViewId;

        private void Awake()
        {
            Log = Logger;
            try
            {
                _toggleItem = AccessTools.Method(typeof(ItemToggle), "ToggleItem", new Type[] { typeof(bool), typeof(int) });
                try { _localViewId = AccessTools.Method(typeof(SemiFunc), "PhotonViewIDPlayerAvatarLocal"); } catch { }
                var shoot = AccessTools.Method(typeof(ItemGun), "Shoot", new Type[0]);
                var harmony = new Harmony("cn_xc.AWPGunFix");
                if (shoot != null && _toggleItem != null)
                {
                    harmony.Patch(shoot, null, new HarmonyMethod(typeof(Plugin).GetMethod("ShootPostfix", BindingFlags.Static | BindingFlags.NonPublic)));
                    Log.LogInfo("AWPGunFix 已加载（AWP 单发）");
                }
                else Log.LogWarning("AWPGunFix: 找不到 ItemGun.Shoot / ItemToggle.ToggleItem");
            }
            catch (Exception ex) { Log.LogError("AWPGunFix 加载失败: " + ex); }
        }

        private static bool IsAwp(ItemGun gun)
        {
            try
            {
                if (gun == null) return false;
                string n = gun.gameObject.name;
                return !string.IsNullOrEmpty(n) && n.IndexOf("AWP", StringComparison.OrdinalIgnoreCase) >= 0;
            }
            catch { return false; }
        }

        internal static void ShootPostfix(ItemGun __instance, bool __result)
        {
            try
            {
                if (!IsAwp(__instance)) return;
                if (!__result) return;
                ItemToggle toggle = __instance.GetComponent<ItemToggle>();
                if (toggle == null || !toggle.toggleState) return;
                int viewId = 0;
                try { if (_localViewId != null) viewId = (int)_localViewId.Invoke(null, null); } catch { }
                _toggleItem.Invoke(toggle, new object[] { false, viewId });
            }
            catch { }
        }
    }
}
