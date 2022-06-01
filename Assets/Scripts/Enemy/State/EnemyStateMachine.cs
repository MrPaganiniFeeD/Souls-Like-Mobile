using System.Collections.Generic;
using Fabrics;
using PlayerLogic.State.StateMachine;
using PlayerLogic.States;
using UnityEngine;
using Zenject;

namespace Enemy.State
{
    public class EnemyStateMachine : MonoBehaviour, IStateMachine
    {
        private IFabricState _fabricState;
        private IFactoryTransition _fabricTransition;

        
        [Inject]
        public void Constructor(Player player)
        {
            IObservableTransform observableTransform = player.GetComponent<IObservableTransform>();
            /*_fabricTransition = new FactoryEnemyTransition(gameObject, observableTransform);
            _fabricState = new FabricEnemyState(observableTransform, gameObject, _fabricTransition);*/
        }

        private void Start()
        {
        }

        private void Update()
        {
        }
    }
}