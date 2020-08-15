using System.ComponentModel;
using Exiled.API.Interfaces;

namespace Scp079ApBugHotFix
{
    public class ExiledSetting : IConfig
    {
        [Description("플러그인 기능을 사용할지 여부를 설정합니다.")]
        public bool IsEnabled { get; set; } = true;
    }
}