using System.Collections.Generic;
using PlayerLogic.States.Transition;

namespace Fabrics
{
    public interface IFactoryTransition
    {
        ITransition CreateTransition(TypeTransitions typeTransitions);
        List<ITransition> CreatTransitions(IEnumerable<TypeTransitions> typeTransitions);
    }
}
