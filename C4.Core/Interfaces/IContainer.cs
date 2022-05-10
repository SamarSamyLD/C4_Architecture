using OnlineShoppingArchticture.Application.Models;
using Structurizr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingArchticture.Application.Interfaces
{
    public interface IContainer
    {
        Container AddContainer(SoftwareSystem softwareSystem, ContainerModel containerModel);
    }
}
