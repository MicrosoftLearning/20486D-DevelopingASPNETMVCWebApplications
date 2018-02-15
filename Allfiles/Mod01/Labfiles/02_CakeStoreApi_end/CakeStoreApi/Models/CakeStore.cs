namespace CakeStoreApi.Models
{
    public class CakeStore
    {
        //Id. This is the primary key
        public int Id { get; set; }

        //CakeType. This is the Cake Type
        public string CakeType { get; set; }

        //Quantity. This is the Cakes Quantity
        public int Quantity { get; set; }
    }
}
