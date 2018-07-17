using System.Collections.Generic;
using System.Linq;

namespace Severino.Common.Util
{
    /// <summary>
    /// Classe com método auxiliar para cque tem o mesmo nome opiar as propriedades dos objetos
    /// </summary>
    public static class CopyPropertiesExtension
    {
        private static readonly List<string> IgnoredField = new List<string> {"Id", "CreatedAt", "UpdatedAt"};

        /// <summary>
        /// Copia as propriedades para outra entidade
        /// </summary>
        /// <remarks>
        /// Realiza a busca das propriedades que são publicas e copia para o novo objeto.
        /// Só as propriedades que coincidem nos dois objetos
        /// </remarks>
        /// <param name="source">Objeto de origem com os valores que devem ser copiados</param>
        /// <param name="dest">Objeto de destino que irá receber os novos valores</param>
        /// <param name="includeAll">Indica se devem ser copiadas todas as propriedades</param>
        /// <typeparam name="T">Tipo do objeto de origem</typeparam>
        /// <typeparam name="TU">Tipo do objeto de destino</typeparam>
        /// <returns></returns>
        public static void CopyPropertiesTo<T, TU>(this T source, TU dest, bool includeAll = false)
        {
            var sourceProps = typeof (T).GetProperties().Where(x => x.CanRead).ToList();
            var destProps = typeof(TU).GetProperties()
                .Where(x => x.CanWrite)
                .ToList();

            foreach (var sourceProp in sourceProps)
            {
                if (!includeAll && IgnoredField.Any(x => x == sourceProp.Name)) continue;
                    
                if (destProps.All(x => x.Name != sourceProp.Name)) continue;
             
                var p = destProps.First(x => x.Name == sourceProp.Name);
                if (p.CanWrite)
                {
                    // check if the property can be set or no.
                    p.SetValue(dest, sourceProp.GetValue(source, null), null);
                }
            }
        }
    }
}