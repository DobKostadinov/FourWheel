using AutoMapper;
using FourWheels.Data.Models;
using FourWheels.Web.Infrastructure.Contracts;
using FourWheels.Web.Models.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FourWheels.Web.Models.CarViewModels
{
    public class CarAdFullDetailsViewModel
    {
        public CarAdFullInfoViewModel AdInfo { get; set; }

        public UserDetailsViewModel UserDetails { get; set; }

    }
}