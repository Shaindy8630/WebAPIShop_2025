using System.ComponentModel.DataAnnotations;

namespace Entity
{

    public partial class Users
    {
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserPassword { get; set; }
    }
}


