﻿using ProjetoEngIII.Model;
using ProjetoEngIII.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace ProjetoEngIII.DAO
{
    public class TipoDAO
    {
        public void Salvar(EntidadeDominio entidade)
        {
            Tipo tipo = (Tipo)entidade;
            #region Conexão BD
            Conexao conn = new Conexao();
            var conexao = conn.Connection();
            var objConn = new SqlConnection(conexao);
            if (objConn.State == ConnectionState.Closed)
            {
                objConn.Open();
            }
            var objComando = new SqlCommand();
            objComando.Connection = objConn;
            #endregion

            try
            {
                var nmClass = entidade.GetType().Name.ToLower();
                StringBuilder strSQL = new StringBuilder();
                strSQL.Append("INSERT INTO ");
                strSQL.Append("tb_");
                strSQL.Append(nmClass);
                strSQL.Append("(nome, descricao) ");
                strSQL.Append("VALUES (@nome,@descricao)");

                objComando.CommandText = strSQL.ToString();
                objComando.Parameters.AddWithValue("@nome", tipo.GetNome());
                objComando.Parameters.AddWithValue("@descricao", tipo.GetDescricao());

                if (objComando.ExecuteNonQuery() < 1)
                {
                    throw new Exception("Erro ao inserir registro " + tipo.GetNome());
                }
                objConn.Close();
            }
            catch (Exception ex)
            {
                if (objConn.State == ConnectionState.Open)
                {
                    objConn.Close();
                }

                throw new Exception("Erro ao inserir registro " + ex.Message);
            }
        }
    }
}