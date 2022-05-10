using Structurizr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingArchticture.Application.Models
{
    public class RelationshipModel
    {
        public StaticStructureElement? Destination { get; }
        public string? Label { get; private set; }
    }
}
