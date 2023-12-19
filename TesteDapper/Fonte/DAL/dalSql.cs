using Dapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace TesteDapper.Fonte.DAL
{
    public class dalSql
    {
        public async static Task<T> buscarUnico<T>(string ssql, object parametros)
        {
            var tipoObjeto = typeof(T);

            var map = new CustomPropertyTypeMap(tipoObjeto, (type, columnName) => type.GetProperties().FirstOrDefault(prop => mapearObjeto(prop) == columnName.ToLower()));
            SqlMapper.SetTypeMap(tipoObjeto, map);

            var resultado = (await dalConexao.conexao.QueryFirstOrDefaultAsync<T>(sql: ssql, param: parametros));

            return resultado;
        }

        public async static Task <List<T>> buscarTodos<T>(string ssql, object parametros)
        {
            var tipoObjeto = typeof(T);

            var map = new CustomPropertyTypeMap(tipoObjeto, (type, columnName) => type.GetProperties().FirstOrDefault(prop => mapearObjeto(prop) == columnName.ToLower()));
            SqlMapper.SetTypeMap(tipoObjeto, map);

            var resultado = await dalConexao.conexao.QueryAsync<T>(sql: ssql, param: parametros);

            return resultado.ToList();
        }

        public async static Task<List<TEntity>> buscarTodosJoin<TEntity, TManyEntity>(string ssql, object parameters, string chavePrimaria, string chaveEstrangeira)
        {
            var dictionary = new Dictionary<int, TEntity>();

            var result = await dalConexao.conexao.QueryAsync<TEntity, TManyEntity, TEntity>(ssql,
                (one, many) =>
                {
                    var onePropertyInfo = typeof(TEntity).GetProperty(chavePrimaria);
                    var oneId = onePropertyInfo?.GetValue(one);

                    if (oneId == null)
                        throw new InvalidOperationException($"A propriedade {chavePrimaria} não pode ser nula.");

                    if (!dictionary.TryGetValue((int)oneId, out var currentOne))
                    {
                        currentOne = one;
                        dictionary.Add((int)oneId, currentOne);
                    }

                    var foreignKeyPropertyInfo = typeof(TManyEntity).GetProperty(chaveEstrangeira);
                    var foreignKeyValue = foreignKeyPropertyInfo?.GetValue(many);

                    var listPropertyName = typeof(TEntity)
                        .GetProperties()
                        .Where(p => p.PropertyType == typeof(List<TManyEntity>))
                        .Select(p => p.Name)
                        .FirstOrDefault();

                    var list = (IList<TManyEntity>)currentOne?.GetType()?.GetProperty(listPropertyName)?.GetValue(currentOne);

                    if (list == null)
                    {
                        list = new List<TManyEntity>();
                        currentOne.GetType().GetProperty(listPropertyName)?.SetValue(currentOne, list);
                    }

                    list.Add(many);

                    return currentOne;
                },
                parameters,
                splitOn: $"{chaveEstrangeira}",
                commandTimeout: 1200
            );

            return result.Distinct().ToList();
        }

        private static async Task<int> inserirNovo<T>(T objeto)
        {
            var parametros = new List<string>();

            var tipoDoObjeto = objeto.GetType();

            foreach (var propriedade in tipoDoObjeto.GetProperties())
            {
                var tipoPropriedade = propriedade.PropertyType;
                var nomePropriedade = mapearObjeto(propriedade);
                var valorPropriedade = propriedade.GetValue(objeto);

                if (valorPropriedade != null && (tipoPropriedade.IsPrimitive || tipoPropriedade == typeof(string) || tipoPropriedade == typeof(decimal)))
                {
                    if (!object.Equals(valorPropriedade, verificarValor(tipoPropriedade)))
                    {
                        parametros.Add(nomePropriedade);
                    }
                }
            }

            var listaCamposSsql = new List<string>();
            var listaParametrosSsql = new List<string>();

            foreach (var item in parametros)
            {
                var nomeCampo = item;

                listaCamposSsql.Add($"{nomeCampo}");
                listaParametrosSsql.Add($"@{nomeCampo}");
            }

            var nomeTabela = receberNomeTabela(tipoDoObjeto);
            var camposSsql = string.Join(", ", listaCamposSsql);
            var parametrosSsql = string.Join(", ", listaParametrosSsql);

            var ssql = $"INSERT INTO {nomeTabela} ({camposSsql}) VALUES ({parametrosSsql});";
            var resultado = await dalConexao.conexao.ExecuteScalarAsync<int>(ssql, objeto);
            return resultado;
        }

        private static async void testeInsert<T>(T objeto)
        {
            var tipoDoObjeto = objeto.GetType();
            var codigoCadastro = await inserirNovo(objeto);

            foreach (var propriedade in tipoDoObjeto.GetProperties())
            {
                var tipoPropriedade = propriedade.PropertyType;
                var valorPropriedade = propriedade.GetValue(objeto);

                if (tipoPropriedade.IsClass && tipoPropriedade != typeof(string))
                {
                    
                }
            }
        }

        private static string receberNomeTabela(MemberInfo elemento)
        {
            var nomeTabela = "";

            var tabela = Attribute.GetCustomAttribute(elemento, typeof(TableAttribute)) as TableAttribute;

            if (tabela != null) { nomeTabela = tabela.Name; }

            return nomeTabela;
        }

        private static object verificarValor(Type type)
        {
            return type.IsValueType ? Activator.CreateInstance(type) : null;
        }

        private static string mapearObjeto(MemberInfo member)
        {
            if (member == null) return null;

            var attrib = (DescriptionAttribute)Attribute.GetCustomAttribute(member, typeof(DescriptionAttribute), false);
            return (attrib?.Description ?? member.Name).ToLower();
        }
    }
}
