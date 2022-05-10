using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShoppingArchticture.Application.Interfaces;
using OnlineShoppingArchticture.Application.Models;
using OnlineShoppingArchticture.Constants;
using OnlineShoppingArchticture.Structures;
using Structurizr;
using Styles = OnlineShoppingArchticture.Constants.Styles;

namespace OnlineShoppingArchticture.Diagrams
{
    public class OnlineShoppingDiagram
    {
        private readonly IWorkspace _workspace;
        private readonly ISoftwareSystem _softwareSystem;
        private readonly IContainer _container;
        private readonly IComponent _component;
        private readonly IPerson _person;
        private readonly IRelationship _relationship;


        public OnlineShoppingDiagram(IWorkspace workspace, ISoftwareSystem softwareSystem, IContainer container, IPerson person, IRelationship relationship, IComponent component)
        {
            _workspace = workspace;
            _softwareSystem = softwareSystem;
            _container = container;
            _person = person;
            _relationship = relationship;
            _component = component;
        }

        public Workspace Build()
        {
            Workspace workspace = _workspace.Create("Online Shopping System", "");
            ViewSet views = workspace.Views;

            
            // Add systems
            SoftwareSystem onlineShoppingSystem = CreateSoftwareSystem(workspace.Model, Systems.onlineShopping);
            SoftwareSystem paymentGateway = CreateSoftwareSystem(workspace.Model, Systems.paymentGateway);
            SoftwareSystem fulfillmentSystem = CreateSoftwareSystem(workspace.Model, Systems.fulfillmentSystem);
            SoftwareSystem emailsystem = CreateSoftwareSystem(workspace.Model, Systems.emailSystem);


            //Add Persons
            Person customer = CreatePerson(workspace.Model, People.Customer);


            // Add Containers
            Container spaContainer = CreateContainer(onlineShoppingSystem, Containers.Spa);
            Container shoppingAPIContainer = CreateContainer(onlineShoppingSystem, Containers.ShoppingAPI);
            Container shopDBContainer = CreateContainer(onlineShoppingSystem, Containers.ShopDB);
            Container authAPIContainer = CreateContainer(onlineShoppingSystem, Containers.AuthAPI);
            Container authDBContainer = CreateContainer(onlineShoppingSystem, Containers.AuthDB);


            // Add Components

            Component purchaseController = CreateComponent(shoppingAPIContainer, Components.PurchaseController); 
            Component service = CreateComponent(shoppingAPIContainer, Components.Service);  
            Component listingModel = CreateComponent(shoppingAPIContainer, Components.ListingModel);  
            Component ordersModel = CreateComponent(shoppingAPIContainer, Components.OrdersModel);  
            Component shoppingCartModel = CreateComponent(shoppingAPIContainer, Components.shoppingCartModel);
            
            
            // Add Relationship
            _relationship.CreateRelationship<SoftwareSystem>(customer, onlineShoppingSystem, "Order Products using", "");
            _relationship.CreateRelationship<SoftwareSystem>(onlineShoppingSystem, fulfillmentSystem, "Sends Orders to", "");
            _relationship.CreateRelationship<SoftwareSystem>(onlineShoppingSystem, paymentGateway, "makes payments using", "");
            _relationship.CreateRelationship<Container>(customer, spaContainer, "Login and purchases Using", "");
            _relationship.CreateRelationship<Container>(spaContainer, authAPIContainer, "Authenticates existing customer", "[json/https]");

            _relationship.CreateRelationship<Container>(spaContainer, shoppingAPIContainer, "Retrieves lists and place orders using", "[json/https]");
            _relationship.CreateRelationship<Container>(spaContainer, authAPIContainer, "Register new customer", "[json/https]");
            _relationship.CreateRelationship<SoftwareSystem>(spaContainer, paymentGateway, "makes payments using", "[json/https]");
            _relationship.CreateRelationship<Container>(shoppingAPIContainer, shopDBContainer, "Stores / Read / Write", "[TCP/IP]");
            _relationship.CreateRelationship<Container>(shoppingAPIContainer, fulfillmentSystem, "sends message to place order", "[json/https]");
            _relationship.CreateRelationship<Container>(authAPIContainer, authDBContainer, "Stores / Read / Write", "[TCP/IP]");

            _relationship.CreateRelationship<Component>(spaContainer, purchaseController, "Retrives listings/orders/basket using", "[json/https]");
            _relationship.CreateRelationship<Component>(purchaseController, service, "Uses", "");
            _relationship.CreateRelationship<Component>(service, listingModel, "Uses", "");
            _relationship.CreateRelationship<Component>(service, shoppingCartModel, "Uses", "");
            _relationship.CreateRelationship<Component>(service, ordersModel, "Uses", "");
            _relationship.CreateRelationship<Component>(service, fulfillmentSystem, "Send messages to place orders using", "");
            _relationship.CreateRelationship<Component>(shoppingCartModel, shopDBContainer, "Read/writes", "");




            _relationship.CreateRelationship<SoftwareSystem>(emailsystem, onlineShoppingSystem, "Send emails using", "");


            // Styles
            Styles.Add(views);


            // Views

            // 1. Context Diagram
            SystemContextView systemContextView = views.CreateSystemContextView(onlineShoppingSystem, "SystemContext", "The system context diagram for Online Shopping System.");
            systemContextView.AddAllPeople();
            systemContextView.AddAllSoftwareSystems();

            // 2. Container Diagram
            ContainerView containerView = views.CreateContainerView(onlineShoppingSystem, "Containers", "The container diagram for the online shopping system.");
            containerView.Add(customer);
            containerView.AddAllContainers();
            containerView.AddAllSoftwareSystems();

            // 3. Component diagram
            ComponentView componentView = views.CreateComponentView(shoppingAPIContainer, "Components", "The component diagram for the API Application.");
            componentView.Add(spaContainer);
            componentView.Add(shopDBContainer);
            componentView.AddAllComponents();
            componentView.Add(fulfillmentSystem);

            

            return workspace;



        }

        SoftwareSystem CreateSoftwareSystem(Model model, SoftwareSystemModel softwareSystemModel)
        {
            return _softwareSystem.Create(model, softwareSystemModel);
        }  
        Person CreatePerson(Model model,PersonModel personModel )
        {
           return _person.AddPerson(model, personModel);
        }
        Container CreateContainer(SoftwareSystem softwareSystem, ContainerModel containerModel)
        {
            return _container.AddContainer(softwareSystem, containerModel);
        }
        Component CreateComponent(Container container, ComponentModel componentModel)
        {
            return _component.AddComponent(container, componentModel);
        }



       

    }
}
