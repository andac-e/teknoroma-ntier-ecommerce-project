using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Enums
{
    public enum EmployeeType
    {
        [Display(Name = "Genel Müdür")]
        BranchManager = 1,
        [Display(Name = "Satış Temsilcisi")]
        SalesRepresentative = 2,
        [Display(Name = "Depo Temsilcisi")]
        WarehouseRepresentative = 3,
        [Display(Name = "Muhasebe")]
        AccountingRepresentative = 4,
        [Display(Name = "Teknik Servis")]
        TechnicalServiceRepresentative = 5

    }
}
