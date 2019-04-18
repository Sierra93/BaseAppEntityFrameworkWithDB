using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TestAsp.NetCoreMvc.Models {
    //модель для работы с БД через Entity Framework
    //эта модель представляет данные, которые будут храниться в БД
    public class Phone {
        public int Id { get; set; }
        public string Name { get; set; } // название смартфона
        public string Company { get; set; } // компания
        public int Price { get; set; } // цена
    }
}
