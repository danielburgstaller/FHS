namespace FHS_Example.Service
{

    public class Result
    {
        public List<LibraryDTO> results { get; set; }
    }
    public class LibraryDTO
    {
        public string name { get; set; }
        public string latest { get; set; }
    }
}
