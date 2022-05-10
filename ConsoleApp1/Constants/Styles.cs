using Structurizr;

namespace OnlineShoppingArchticture.Constants
{
    public static class Styles
    {
       public static void Add(ViewSet views)
        {
            // colours, shapes and other diagram styling
            Structurizr.Styles styles = views.Configuration.Styles;

            styles.Add(new ElementStyle(Tags.SoftwareSystem) { Background = "#1168bd", Color = "#ffffff" });
            styles.Add(new ElementStyle(Tags.ExternalSystem) { Background = "#999999", Color = "#ffffff" });
            styles.Add(new ElementStyle(Tags.Person) { Background = "#08427b", Color = "#ffffff", Shape = Shape.Person, FontSize = 22 });
            styles.Add(new ElementStyle(Tags.WebBrowserTag) { Background = "#438dd5", Color = "#ffffff", Shape = Shape.WebBrowser });
            styles.Add(new ElementStyle(Tags.APITag) { Background = "#438dd5", Color = "#ffffff" }) ;
            styles.Add(new ElementStyle(Tags.DatabaseTag) { Background = "#85bbf0", Color = "#000000", Shape = Shape.Cylinder });
            styles.Add(new ElementStyle(Tags.Component) { Background = "#85bbf0", Color = "#000000", Shape = Shape.Component });
        }

    }
}
