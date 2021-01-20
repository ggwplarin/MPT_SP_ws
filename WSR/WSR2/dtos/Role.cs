namespace WSR2.dtos
{
    public class Role
    {
        public int ID { get; set; }
        public string Title { get; set; }

        public Role()
        {

        }
        public Role(int id, string title)
        {
            ID = id;
            Title = title;
        }
    }
}