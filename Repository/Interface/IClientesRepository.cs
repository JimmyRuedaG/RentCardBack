using Microsoft.AspNetCore.Mvc;
using RentCard.Models.BD;
using RentCard.Models.DTO;

namespace RentCard.Repository.Interface
{
    public interface IClientesRepository
    {
        List<Cliente> ListarClientes();
        List<DTO_Consultar> consultar();

        List<DTO_CantidadAlquiler>cantidadAlquiler();

    }

}
