using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSTower.Domains;

namespace WSTower.Interfaces
{
    interface IJogoRepository
    {
        List<Jogo> ListarTodosJogos();

        void CadastrarJogo(Jogo jogo);

        void Atualizar(int id,Jogo jogoAtualizado);

        List<Jogo> ListarPorData(string DataJogo);

        List<Jogo> ListarPorEstadio(string NomeEstadio);

        List<Selecao> ListarNomeSelecao(string NomeSelecao);
    }
}
