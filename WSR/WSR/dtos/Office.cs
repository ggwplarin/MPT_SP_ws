namespace WSR.dtos
{
    public class Office
    {
        public int ID { get; set; }
        public int CountryID { get; set; }
        public string Title { get; set; }
        public string Phone { get; set; }
        public string Contact { get; set; }

        public Office()
        {
        }

        public Office(int id, int countryId, string title, string phone, string contact)
        {
            ID = id;
            CountryID = countryId;
            Title = title;
            Phone = phone;
            Contact = contact;
        }
    }
}