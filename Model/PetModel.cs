using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CrudWinFormMVP.Model
{
    public class PetModel
    {
        // Fields 
        private int id;
        private string name;
        private string type;
        private string colour;

        // properties - Validations
        [DisplayName("Pet ID")]
        public int Id
        {
            get { return id; }
            set { id = value; }

        }
        [DisplayName("Pet Name")]
        [Required(ErrorMessage = "Pet name is requerd")]
        [StringLength(50, MinimumLength =3, ErrorMessage = "Pet name musst be between 3 and 50 characters")]
        public String Name
        {
            get { return name; }
            set { name = value; }

        }
        [DisplayName("Pet Type")]
        [Required(ErrorMessage = "Pet type is requerd")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Pet type musst be between 3 and 50 characters")]
        public string Type
        {
            get { return type; }
            set { type = value; }

        }
        [DisplayName("Pet Color")]
        [Required(ErrorMessage = "Pet color is requerd")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Pet name musst be between 3 and 50 characters")]
        public string Colour
        {
            get { return colour; }
            set { colour = value; }

        }
    }
}
