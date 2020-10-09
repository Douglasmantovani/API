using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSTower.Domains;
using WSTower.Interfaces;

namespace WSTower.Repositories
{
    public class JogadorRepository: IJogadorRepository
    {
        TowerContext ctx = new TowerContext();


        public List<Jogador> ListarTodos()
        {
            return ctx.Jogador.ToList();
        }


		public Jogador BuscarPorNome(string nome)
	{
		Jogador jogadorBuscado = ctx.Jogador.Select(j => new Jogador()
		{
			Id = j.Id,
			Foto = j.Foto,
			Posicao = j.Posicao,
			Nome = j.Nome,
			Nascimento = j.Nascimento,
			NumeroCamisa = j.NumeroCamisa,
			Qtdegols = j.Qtdegols,
			QtdecartoesAmarelo = j.QtdecartoesAmarelo,
			QtdecartoesVermelho = j.QtdecartoesVermelho,
			Qtdefaltas = j.Qtdefaltas,
			Informacoes = j.Informacoes,
			SelecaoId = j.SelecaoId,

			Selecao = new Selecao()
			{
				Bandeira = j.Selecao.Bandeira,
				Nome = j.Selecao.Nome
			}


		}).FirstOrDefault(j => j.Nome == nome);

		if (jogadorBuscado != null)
		{

			if (jogadorBuscado.Posicao == "Goleiro")
			{

				jogadorBuscado.NumeroCamisa = 0;

			}


			return jogadorBuscado;
		}

		return null;

	}










	}
}
