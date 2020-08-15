using Exiled.Events.EventArgs;

namespace Scp079ApBugHotFix
{
    public static class EventHandlers
    {
        public static void OnPlayerJoined(JoinedEventArgs ev)
        {
            ev.Player.SendConsoleMessage(
                "\n\n\n" +
                "본 서버는 호류서버에서 배포한 SCP-079\n" +
                "AP 전력 버그 핫픽스 플러그인을 사용 중입니다.\n" +
                "\n" +
                "문의: @호류#7777", "yellow"
            );
        }
    }
}