using QuickBuy.Domain.Contratos;
using QuickBuy.Repository.Contexto;
using System.Collections.Generic;
using System.Linq;

namespace QuickBuy.Repository.Repositorios
{
    public class BaseRepositorio<TEntity> : IBaseRepositorio<TEntity> where TEntity : class
    {
        protected readonly QuickBuyContexto Context;
        public BaseRepositorio(QuickBuyContexto contexto)
        {
            Context = contexto;
        }

        public void Adicionar(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            Context.SaveChanges();
        }

        public void Atualizar(TEntity entity)
        {
            Context.Set<TEntity>().Update(entity);
            Context.SaveChanges();
        }

        public void Remover(TEntity entity)
        {  
            Context.Set<TEntity>().Remove(entity);
            Context.SaveChanges();
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return Context.Set<TEntity>().ToList();
        }
               
        public TEntity ObterPorId(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}

/*
    Classes de repository/services ou DAO, são responsavel pela
    persistencia na base de dados.
    Nesse modelo ela implementa uma interface de contrados em 
    dominio, e implementa suas classes abstratas.
    OBS: AS DEMAIS CLASSES DESSA CAMADA SÃO IMPLEMENTADAS DE OUTRA FORMA.
    SENDO QUE AS MESMA IMPLEMENTARAM ESSE MESMA CLASSE TIPANDO COM SUAS
    RESPECTIVAS CLASSES, E TAMBÉM IMPLEMENTARÃO AS INTERFACES EM CONTRATOS
    DA MESA ENTIDADE.
     
*/
