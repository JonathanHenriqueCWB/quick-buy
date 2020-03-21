using QuickBuy.Domain.Contratos;
using QuickBuy.Repository.Contexto;
using System.Collections.Generic;
using System.Linq;

namespace QuickBuy.Repository.Repositorios
{
    public class BaseRepositorio<TEntity> : IBaseRepositorio<TEntity> where TEntity : class
    {
        protected readonly QuickBuyContexto Contexto;
        public BaseRepositorio(QuickBuyContexto contexto)
        {
            Contexto = contexto;
        }

        public void Adicionar(TEntity entity)
        {
            Contexto.Set<TEntity>().Add(entity);
            Contexto.SaveChanges();
        }

        public void Atualizar(TEntity entity)
        {
            Contexto.Set<TEntity>().Update(entity);
            Contexto.SaveChanges();
        }

        public void Remover(TEntity entity)
        {
            Contexto.Set<TEntity>().Remove(entity);
            Contexto.SaveChanges();
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return Contexto.Set<TEntity>().ToList();
        }
               
        public TEntity ObterPorId(int id)
        {
            return Contexto.Set<TEntity>().Find(id);
        }

        public void Dispose()
        {
            Contexto.Dispose();
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
