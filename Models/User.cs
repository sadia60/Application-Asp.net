using System.ComponentModel.DataAnnotations;


namespace ColdWhereApplication.Models
{
    public class User

    {
        //{ message_type = "login_user", email ="hello", password = "123" }
        public string message_type
        {
            get;
            set;
        }

        public string email
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string password { get; set; }


    }
}