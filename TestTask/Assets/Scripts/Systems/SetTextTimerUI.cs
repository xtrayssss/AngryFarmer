using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    internal class SetTextTimerUI : IEcsRunSystem
    {
        private EcsFilter<TimerUIComponent, TimerComponent> _timerFilter;

        public void Run()
        {
            foreach (var timerUIIndex in _timerFilter)
            {
                ref var timerUIComponent = ref _timerFilter.Get1(timerUIIndex);

                ref var timerComponent = ref _timerFilter.Get2(idx: timerUIIndex);

                SetTextMeshPro(ref timerUIComponent, ref timerComponent);
            }
        }

        private void SetTextMeshPro(ref TimerUIComponent timerUIComponent, ref TimerComponent timerComponent) =>
            timerUIComponent.TextMeshPro.SetText(Mathf.Round(timerComponent.Timer).ToString());
    }
}