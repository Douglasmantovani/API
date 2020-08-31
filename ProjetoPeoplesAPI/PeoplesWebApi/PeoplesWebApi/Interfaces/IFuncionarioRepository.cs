using PeoplesWebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeoplesWebApi.Interfaces
{
    interface IFuncionarioRepository
    {
        List<Funcionarios> ListarTodods();

        bool Cadastrar(Funcionarios funcionario);

        void Atualizar(int id, Funcionarios funcionarios);

        void Deletar(int id);

        Funcionarios BuscarPorID(int id);

        List<Funcionarios> BuscarPorNome(string nome);
    }
}
