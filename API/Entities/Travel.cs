namespace API.Model
{
    public class Travel
    {
        public string id { get; set; }
        public string FromContry { get; set; }

        public string ToContry { get; set; }
        public DateTime TimeStamp { get; set; }

        public int TravelPrice { get; set; }
        public int PassengerCount { get; set; }



    }
}
