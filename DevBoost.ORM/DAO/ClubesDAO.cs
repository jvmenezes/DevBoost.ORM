using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;
using Dapper.Contrib.Extensions;
using DevBoost.ORM.Models;
using System.Collections.Generic;

namespace DevBoost.ORM.DAO {
  public class ClubesDAO {
	private IConfiguration _configuracoes;

	public ClubesDAO(IConfiguration config) {
	  _configuracoes = config;
	}

	public List<Clube> ObterUm(string codIndicador) {
	  using (SqlConnection conexao = new SqlConnection(
		  _configuracoes.GetConnectionString("BaseIndicadores"))) {
		return conexao.GetAll<Clube>().AsList();
	  }
	}

	public Clube ObterUmQueryDynamic(string codIndicador) {
	  using (SqlConnection conexao = new SqlConnection(
		  _configuracoes.GetConnectionString("BaseIndicadores"))) {
		return conexao.QueryFirstOrDefault<Clube>(
			"SELECT Sigla, NomeIndicador, UltimaAtualizacao, Valor " +
			"FROM dbo.Indicadores " +
			"WHERE Sigla = @CodIndicador ",
			new { CodIndicador = codIndicador }
		);
	  }
	}

	public List<Clube> ObterTodos() {
	  using (SqlConnection conexao = new SqlConnection(
		  _configuracoes.GetConnectionString("BaseIndicadores"))) {
		var list = conexao.GetAll<Clube>();
		return list.AsList();
	  }
	}
  }
}