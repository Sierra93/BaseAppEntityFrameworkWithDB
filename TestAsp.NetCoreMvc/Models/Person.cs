using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TestAsp.NetCoreMvc.Models {
    //модель данных
    public class Person {
        [Display(Name = "Имя")]
        public string sName { get; set; }
        [Display(Name = "Электронная почта")]
        public string sEmail { get; set; }
        [Display(Name = "Домашняя страница")]
        public string sHomePage { get; set; }
        [DataType(DataType.Password)]
        public string sPassword { get; set; }
        [Display(Name = "Возраст")]
        public int nAge { get; set; }
    }
}
