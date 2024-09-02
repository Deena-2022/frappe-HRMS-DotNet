using System.ComponentModel.DataAnnotations;

namespace BOC.Domain.Enum
{
    public  enum RoleEnums
    {
        [Display(Name = "Sales Person")]
        SalesPerson = 1,
        [Display(Name = "Administrator")]
        Admin = 2,
        [Display(Name = "Field User")]
        FieldUser = 3
    }
}
