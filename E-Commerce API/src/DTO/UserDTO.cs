namespace E_Commerce_API.src.DTO
{
    public class UserDTO
    {
        private string _name;
        
        public UserDTO(string name)
        {
            _name = name;
        }

        public UserDTO() 
        { 
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}
