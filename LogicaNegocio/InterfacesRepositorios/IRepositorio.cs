﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorio<T>
    {
        void Agregar(T obj);
        void Remove(T obj);
        void Update(T obj);
        IEnumerable<T> FindAll();
        T FindById(int id);



    }
}
