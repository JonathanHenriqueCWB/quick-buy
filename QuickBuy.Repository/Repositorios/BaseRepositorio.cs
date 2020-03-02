using QuickBuy.Domain.Contratos;
using System.Collections.Generic;

namespace QuickBuy.Repository.Repositorios
{
    public class BaseRepositorio<TEntity> : IBaseRepositorio<TEntity> where TEntity : class
    {
        public BaseRepositorio()
        {

        }

        public void Adicionar(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public void Atualizar(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public TEntity ObterPorId(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            throw new System.NotImplementedException();
        }

        public void Remover(TEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}

/*
    Classes de repository/services ou DAO, são responsavel pela
    persistencia na base de dados.
    Nessa modelo ela implementa uma interface de contrados em 
    dominio, e implementa suas classes abstratas.
    OBS: AS DEMAIS CLASSES DESSA CAMADA SÃO IMPLEMENTADAS DE OUTRA FORMA.
    SENDO QUE AS MESMA IMPLEMENTARAM ESSE MESMA CLASSE TIPANDO COM SUAS
    RESPECTIVAS CLASSES, E TAMBÉM IMPLEMENTARÃO AS INTERFACES EM CONTRATOS
    DA MESA ENTIDADE.
     
*/
