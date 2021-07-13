namespace _0_Framework.Infrastructure
{
    public class PermissionDTO
    {
        public int Code { get; set; }
        public string Name { get; set; }

        public PermissionDTO(int code, string name)
        {
            Code = code;
            Name = name;
        }
    }
}
