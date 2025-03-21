namespace ReadyForDispatchAPI.ReadyForDispatch.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class CartonWeight
    {
        public string type { get; set; }
        public string description { get; set; }
    }

    public class City
    {
        public string type { get; set; }
        public string description { get; set; }
    }

    public class Containers
    {
        public string type { get; set; }
        public Items items { get; set; }
    }

    public class ContainerType
    {
        public string type { get; set; }
        public string description { get; set; }
        public List<string> @enum { get; set; }
    }

    public class ControlNumber
    {
        public string type { get; set; }
        public string description { get; set; }
    }

    public class Country
    {
        public string type { get; set; }
        public string description { get; set; }
    }

    public class DeliveryAddress
    {
        public string type { get; set; }
        public Properties properties { get; set; }
        public List<string> required { get; set; }
    }

    public class ItemCode
    {
        public string type { get; set; }
        public string description { get; set; }
    }

    public class Items
    {
        public string type { get; set; }
        public Properties properties { get; set; }
        public List<string> required { get; set; }
        public Items items { get; set; }
        public string description { get; set; }
    }

    public class LoadId
    {
        public string type { get; set; }
        public string description { get; set; }
    }

    public class PostalCode
    {
        public string type { get; set; }
        public string description { get; set; }
    }

    public class Properties
    {
        public ControlNumber controlNumber { get; set; }
        public SalesOrder salesOrder { get; set; }
        public Containers containers { get; set; }
        public DeliveryAddress deliveryAddress { get; set; }
        public LoadId loadId { get; set; }
        public ContainerType containerType { get; set; }
        public Items items { get; set; }
        public ItemCode itemCode { get; set; }
        public Quantity quantity { get; set; }
        public CartonWeight cartonWeight { get; set; }
        public Street street { get; set; }
        public City city { get; set; }
        public State state { get; set; }
        public PostalCode postalCode { get; set; }
        public Country country { get; set; }
    }

    public class Quantity
    {
        public string type { get; set; }
        public string description { get; set; }
    }

    public class DispatchRequest
    {
        public string title { get; set; }
        public string type { get; set; }
        public Properties properties { get; set; }
        public List<string> required { get; set; }
    }

    public class SalesOrder
    {
        public string type { get; set; }
        public string description { get; set; }
    }

    public class State
    {
        public string type { get; set; }
        public string description { get; set; }
    }

    public class Street
    {
        public string type { get; set; }
        public string description { get; set; }
    }


}
