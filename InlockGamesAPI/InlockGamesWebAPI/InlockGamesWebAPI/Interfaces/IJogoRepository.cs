using InlockGamesWebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InlockGamesWebAPI.Interfaces
{
    interface IJogoRepository
    {
        List<Jogo> ListarJogos();

        bool Adicionar(Jogo jogo);

        bool Atualizar(int id, Jogo jogo);

        bool Deletar(int id);

        List<Jogo> ListarComEstudio();
    }
}
