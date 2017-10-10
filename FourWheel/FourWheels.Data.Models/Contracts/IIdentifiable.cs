using System;

namespace FourWheels.Data.Models.Contracts
{
    public interface IIdentifiable
    {
        Guid Id { get; set; }
    }
}
