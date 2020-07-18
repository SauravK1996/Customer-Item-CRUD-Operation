using AutoMapper;
using Customer_Item_CRUD_API.Dtos;
using Customer_Item_CRUD_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Item_CRUD_API
{
    public class SalesMapper:Profile
    {
        public SalesMapper()
        {
            CreateMap<Tabsorder, TabsorderDto>().ReverseMap();
        }
    }
}
