using LojaDeGames.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaDeGames.Interfaces
{
    interface IEstudioRepository
    {
        List<Estudio> ListarEstudios();

        bool Adcionar(Estudio estudioNovo);

        bool BuscarEstudio(Estudio estudioNovo);
    }
}
