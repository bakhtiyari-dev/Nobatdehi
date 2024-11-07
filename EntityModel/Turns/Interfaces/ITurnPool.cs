using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.Turns.Interfaces
{
    public interface ITurnPool
    {
        public void Create(TurnPool turnPool);
        public void Update(int id, TurnPool newTurnPool);
        public void Delete(int id);
    }
}
