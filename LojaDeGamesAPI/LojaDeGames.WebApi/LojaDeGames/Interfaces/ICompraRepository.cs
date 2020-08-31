using LojaDeGames.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaDeGames.Interfaces
{
    interface ICompraRepository
    {
        List<Compra> ListarCompras();

        bool AdcionarCompra(int id);
    }
}
