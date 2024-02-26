namespace ApiDay01.DTOs
{
    public class DeptWithStudsName
    {
        public int Department_Number { get; set; }
        public string Department_Name { get; set; }
        public string Department_Manager { get; set; }
        public List<String> Students_Name { get; set; } = new List<String>();

    }
}
