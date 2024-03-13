using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net.NetworkInformation;
using static ChillsRestaurant.Models.ViewModels.IndexCarritoModel;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace ChillsRestaurant.Models.ViewModels
{

    public class IndexCarritoModel
    {

        public List<MenuItem> MenuItems { get; set; }

        public IndexCarritoModel()
        {
            MenuItems = new List<MenuItem>();
        }

        public IndexCarritoModel(List<MenuItem> menuItems)
        {
            MenuItems = menuItems;
        }


    }
}
