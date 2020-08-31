using LojaDeGames.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaDeGames.Interfaces
{
    interface ICarrinhoRepository
    {
        List<Carrinho> ListarCarrinho();

        bool adcionarJogoCarrinho(int id, int idUsuario);

        bool RemoverJogoCarrinho(int id, int idUsuario);
    }
}
