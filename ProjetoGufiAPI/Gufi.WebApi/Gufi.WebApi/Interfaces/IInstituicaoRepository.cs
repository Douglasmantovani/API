using Gufi.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gufi.WebApi.Interfaces
{
    interface IInstituicaoRepository
    {
        List<Instituicao> ListarInstituicao();
        bool Adicionar(Instituicao presencaNovo);
        bool Deletar(int id);
        bool Atualizar(int id,Instituicao instituicao);
    }
}
