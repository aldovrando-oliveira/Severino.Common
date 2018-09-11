using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Severino.Common.Repository.EF
{
    /// <inheritdoc />
    /// <summary>
    /// Classe responsavel por criar uma instancia de DbContext para criar um novo migration ou
    /// executar atualizaçao manual do banco de dados
    /// </summary>
    /// <typeparam name="T">Tipo do DbContext que deve ser utilizado</typeparam>
    public abstract class DesignTimeMySqlDbContextFactory<T> : IDesignTimeDbContextFactory<T>
        where T : DbContext
    {
        /// <inheritdoc />
        public T CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<T>();
            var connectionString = GetConnectionString();
            builder.UseMySql(connectionString);
            var dbContext = (T)Activator.CreateInstance(
                typeof(T),
                builder.Options);
            return dbContext;
        }

        /// <summary>
        /// Retorna a string de conexao com o banco de dados
        /// </summary>
        /// <returns></returns>
        protected abstract string GetConnectionString();
    }
}