namespace WSR.dtos
{
    public class Role
    {
        public int ID { get; set; }
        public int Title { get; set; }

        public Role()
        {
        }
        public Role(int id, int title)
        {
            ID = id;
            Title = title;
        }
    }
}