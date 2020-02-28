using System;
using System.Collections.Generic;
using System.Text;

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
