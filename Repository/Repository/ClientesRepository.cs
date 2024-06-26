using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentCard.Models.BD;
using RentCard.Models.DTO;
using RentCard.Repository.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RentCard.Repository.Repository
{
    public class ClientesRepository : IClientesRepository
    {
        private readonly RentCarDbContext _db;

        public ClientesRepository(RentCarDbContext db)
        {
            _db = db;
        }

        public List<Cliente> ListarClientes()
        {
            return _db.Clientes.ToList();
        }

        public List<DTO_Consultar> consultar()
        {
            var resultado = (from _alquilers in _db.Alquilers
                             join _cliente in _db.Clientes on _alquilers.CedulaCliente equals _cliente.Cedula
                             join _carro in _db.Carros on _alquilers.PlacaCarro equals _carro.Placa
                             select new { _cliente.Cedula, _cliente.Nombre, _alquilers.Fecha, _alquilers.Tiempo, _alquilers.Saldo, _carro.Placa, _carro.Marca }).ToList();

            List<DTO_Consultar> lista = new List<DTO_Consultar>();
            DTO_Consultar elemento;
            foreach (var item in resultado)
            {
                elemento = new DTO_Consultar();
                elemento.Cedula = item.Cedula;
                elemento.Nombre = item.Nombre;
                elemento.FechaAlquiler = item.Fecha;
                elemento.TiempoAlquilado = item.Tiempo;
                elemento.Saldo = item.Saldo;
                elemento.Placa = item.Placa;
                elemento.Marca = item.Marca;

                lista.Add(elemento);
            }
            return lista;

        }


        public List<DTO_CantidadAlquiler> cantidadAlquiler()
        {
            DateTime primerDiaMesActual = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime ultimoDiaMesActual = primerDiaMesActual.AddMonths(1).AddDays(-1);

            var ultimoDiaTotal = (from alquiler in _db.Alquilers
                                  where alquiler.Fecha == _db.Alquilers.Max(a => a.Fecha)
                                  select new DTO_CantidadAlquiler
                                  {
                                      Periodo = "Total último día",
                                      Cantidad_Alquileres = _db.Alquilers.Count(a => a.Fecha == alquiler.Fecha)
                                  }).FirstOrDefault();


            var ultimoMesTotal = (from alquiler in _db.Alquilers
                                  where alquiler.Fecha.Year == DateTime.Now.Year && alquiler.Fecha.Month == DateTime.Now.Month
                                  select new DTO_CantidadAlquiler
                                  {
                                      Periodo = "Total mes actual",
                                      Cantidad_Alquileres = _db.Alquilers.Count(a => a.Fecha.Year == DateTime.Now.Year && a.Fecha.Month == DateTime.Now.Month)
                                  }).FirstOrDefault();

            // Retornar una lista con los resultados
            return new List<DTO_CantidadAlquiler>
    {
        ultimoDiaTotal,
        ultimoMesTotal
    };
        }



    }


}
