namespace d00_5.Models
{
    public class Storage
    {
        private Storage() { }

        public int CountProducts { get; set; }

        public Storage(int capacity) => CountProducts = capacity;

        public bool IsEmpty() => CountProducts > 0 ? false : true;
         
    }
}
