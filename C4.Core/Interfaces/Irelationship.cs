using Structurizr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingArchticture.Application.Interfaces
{
    public interface IRelationship
    {
        void CreateRelationship<T>(StaticStructureElement source, StaticStructureElement dest, string description, string technology);

    }
}
