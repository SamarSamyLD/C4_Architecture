using OnlineShoppingArchticture.Application.Models;
using Structurizr;

namespace OnlineShoppingArchticture.Application.Interfaces
{
    public interface IPerson
    {
       public Person AddPerson(Model model, PersonModel personModel);
    }
}
