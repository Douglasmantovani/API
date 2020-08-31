using LojaDeGames.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaDeGames.Interfaces
{
    interface IJogoRepository
    {
        List<Jogo> ListarJogos();

        bool Adcionar(Jogo JogoNovo);

        bool BuscarJogo(Jogo JogoNovo);

        bool AtualizarPorId(int id, Jogo jogo);
    }
}
