namespace Shop.Models.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }           
        public string UserName { get; set; }  
        public string Email { get; set; }     
        public int FkRole { get; set; }       
        public bool IsActive { get; set; }    
        public DateTime CreatedAt { get; set; } 
        public string Password { get; set; }
    }
}

