using SGC.ApplicationCore.Entity;
using SGC.ApplicationCore.Interfaces.Repository;
using SGC.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SGC.Infrastructure.Repository
{
    public class ClienteRepository : EFRepository<Cliente>, IClienteRepository
    {

        public ClienteRepository(ClienteContext dbContext) : base(dbContext)
        {

        }

        public override Cliente Adicionar(Cliente entity)
        {
            var verificarResutado = "";
            //TODO implementação específica para adicionar um cliente fazendo a sobrescrita de método - polimorfismo
            _dbContext.Set<Cliente>().Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public Cliente ObterPorProfissao(int clienteId)
        {
            return Buscar(x=> x.ProfissoesClientes.Any(p=> p.ClienteId == clienteId))
                .FirstOrDefault();
        }
    }
}
