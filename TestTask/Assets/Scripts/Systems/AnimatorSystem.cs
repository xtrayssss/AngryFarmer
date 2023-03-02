using Components;
using Constants;
using Interfaces;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    internal class AnimatorSystem : IEcsRunSystem
    {
        private static readonly int XHash = Animator.StringToHash(GeneralConstants.XAnimName);
        private static readonly int YHash = Animator.StringToHash(GeneralConstants.YAnimName);
        private static readonly int AgroHash = Animator.StringToHash(GeneralConstants.AgroAnimBoolName);

        private EcsFilter<DirectionComponent, AnimationComponentEnemy> _animatorEnemyFilter;

        private EcsFilter<DirectionComponent, AnimationComponentPlayer> _animatorPlayerFilter;

        public void Run()
        {
            foreach (var playerIndex in _animatorPlayerFilter)
            {
                ref var directionComponent = ref _animatorPlayerFilter.Get1(playerIndex);
                ref var animatorComponent = ref _animatorPlayerFilter.Get2(playerIndex);

                SetAnimationWithSpeed(ref directionComponent, animatorComponent);

                SetAnimationWithoutSpeed(ref directionComponent, animatorComponent);
            }

            foreach (var enemyIndex in _animatorEnemyFilter)
            {
                ref var directionComponent = ref _animatorEnemyFilter.Get1(enemyIndex);
                ref var animatorComponent = ref _animatorEnemyFilter.Get2(enemyIndex);

                SetAgroAnimation(animatorComponent, animatorComponent.IsAgro, directionComponent.Direction);

                SetAnimationWithSpeed(ref directionComponent, animatorComponent);

                SetAnimationWithoutSpeed(ref directionComponent, animatorComponent);
            }
        }

        private void SetAnimationWithSpeed(ref DirectionComponent directionComponent,
            IAnimationComponent animatorComponentEnemy)
        {
            if (!SpeedEqualZero(directionComponent.Direction))
            {
                SetVariablesAnimation(animatorComponentEnemy, directionComponent.Direction.x,
                    directionComponent.Direction.y);

                directionComponent.LastPosition = directionComponent.Direction;
            }
        }

        private void SetAnimationWithoutSpeed(ref DirectionComponent directionComponent,
            IAnimationComponent animationComponentEnemy)
        {
            if (SpeedEqualZero(directionComponent.Direction))
            {
                SetVariablesAnimation(animationComponentEnemy, directionComponent.LastPosition.x,
                    directionComponent.LastPosition.y);
            }
        }

        private void SetVariablesAnimation(IAnimationComponent animationComponentEnemy, float x, float y)
        {
            animationComponentEnemy.Animator.SetFloat(XHash, x);
            animationComponentEnemy.Animator.SetFloat(YHash, y);
        }

        private void SetAgroAnimation(IAnimationComponent animationComponent,bool isAgro, Vector2 direction) =>
            animationComponent.Animator.SetBool(AgroHash, isAgro && !SpeedEqualZero(direction));

        private bool SpeedEqualZero(Vector2 direction) =>
            direction == Vector2.zero;
    }
}