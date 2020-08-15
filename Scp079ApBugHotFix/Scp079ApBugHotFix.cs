using Exiled.API.Enums;
using Exiled.API.Features;
using HarmonyLib;
using Player = Exiled.Events.Handlers.Player;

namespace Scp079ApBugHotFix
{
    public class Scp079ApBugHotFix : Plugin<ExiledSetting>
    {
        private int _patchCounter;
        private Harmony Harmony { set; get; }

        public override PluginPriority Priority { get; } = PluginPriority.Medium;

        public override void OnEnabled()
        {
            Log.Info("활성화 하는 중입니다...");

            Harmony = new Harmony($"exiled.scp079apbughotfixbyhoryu-{_patchCounter}");
            _patchCounter++;
            Harmony.PatchAll();

            Player.Joined += EventHandlers.OnPlayerJoined;
            Log.Info("활성화되었습니다.");
        }

        public override void OnDisabled()
        {
            Harmony?.UnpatchAll();
            Log.Info("비활성화되었습니다.");
        }
    }
}