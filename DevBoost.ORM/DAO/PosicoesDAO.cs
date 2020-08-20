using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;
using Dapper.Contrib.Extensions;
using DevBoost.ORM.Models;
using System.Collections.Generic;

namespace DevBoost.ORM.DAO {
  public class PosicoesDAO {
	private IConfiguration _configuracoes;

	public PosicoesDAO(IConfiguration config) {
	  _configuracoes = config;
	}

	public List<Posicao> ObterUm(string codIndicador) {
	  using (SqlConnection conexao = new SqlConnection(
		  _configuracoes.GetConnectionString("BaseIndicadores"))) {
		return conexao.GetAll<Posicao>().AsList();
	  }
	}

	public Posicao ObterUmQueryDynamic(string codIndicador) {
	  using (SqlConnection conexao = new SqlConnection(
		  _configuracoes.GetConnectionString("BaseIndicadores"))) {
		return conexao.QueryFirstOrDefault<Posicao>(
			"SELECT Sigla, NomeIndicador, UltimaAtualizacao, Valor " +
			"FROM dbo.Indicadores " +
			"WHERE Sigla = @CodIndicador ",
			new { CodIndicador = codIndicador }
		);
	  }
	}

	public List<Posicao> ObterTodos() {
	  using (SqlConnection conexao = new SqlConnection(
		  _configuracoes.GetConnectionString("BaseIndicadores"))) {
		var list = conexao.GetAll<Posicao>();
		return list.AsList();
	  }
	}
  }
}