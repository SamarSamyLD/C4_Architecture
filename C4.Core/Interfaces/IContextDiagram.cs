

using OnlineShoppingArchticture.Application.Models;
using Structurizr;

namespace OnlineShoppingArchticture.Application.Interfaces
{
    public interface IContextDiagram 
    {
        Model CreateContext(List<PersonModel> people, List<SoftwareSystemModel> softwareSystems, Model model);
    }
}
