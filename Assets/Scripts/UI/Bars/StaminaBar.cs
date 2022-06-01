using Infrastructure.Services.PersistentProgress;
using Zenject;

namespace UI.Bars
{
    public class StaminaBar : Bar
    {
        [Inject]
        public override void Constructor(IPersistentProgressService progressService)
        {
            Stat = progressService.PlayerProgress.PlayerState.PlayerStats.Stamina;
            SetValue();
            Stat.StateChanged += UpdateValue;
        }
    }
}
