using System;
using System.Collections.Generic;

namespace QuickBuy.Domain.Contratos
{
    //InterfaceIBaseRepositorio herda de outra interface IDisponsable
    public interface IBaseRepositorio<TEntity> : IDisposable where TEntity : class
    {
        void Adicionar(TEntity entity);
        TEntity ObterPorId(int id);
        IEnumerable<TEntity> ObterTodos();
        void Atualizar(TEntity entity);
        void Remover(TEntity entity);
    }  
}

/*
    Interface base para implementação da camada de persistencia.
    As demais classes dessa camada irão implementar essa mesma classe
    e tbm servirã para camada de configuração nas dependencias, onde as
    mesma irão mapear as propriedades do banco de dados.
*/
