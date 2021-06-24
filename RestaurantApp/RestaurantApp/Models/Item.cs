using System;

namespace RestaurantApp.Models
{
    //<summary>
    //Atributi modela kreiranog za unificiranje podataka o jelu
    //</summary>
    public class Item
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string Picture { get; set; }
        public string Price { get; set; }
    }
}