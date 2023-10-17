using LogicaNegocio.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioParametros: IRepositorio<Parametro>
    {
        Parametro buscarParametroPorNombre(string nombre);
        string buscarValorPorNombre(string nombre);

    }
}
