using InlockGamesWebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InlockGamesWebAPI.Interfaces
{
    interface IEstudioRepository
    {
        List<Estudio> ListarEstudio();

        bool Adicionar(Estudio estudio);

        List<Estudio> ListarEstudioComJogo();
    }
}
