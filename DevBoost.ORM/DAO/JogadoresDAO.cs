using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;
using Dapper.Contrib.Extensions;
using DevBoost.ORM.Models;
using System.Collections.Generic;

namespace DevBoost.ORM.DAO {
  public class JogadoresDAO {
	private IConfiguration _configuracoes;

	public JogadoresDAO(IConfiguration config) {
	  _configuracoes = config;
	}

	public List<Jogador> ObterUm(string codIndicador) {
	  using (SqlConnection conexao = new SqlConnection(
		  _configuracoes.GetConnectionString("BaseIndicadores"))) {
		return conexao.GetAll<Jogador>().AsList();
	  }
	}

	public Jogador ObterUmQueryDynamic(string codIndicador) {
	  using (SqlConnection conexao = new SqlConnection(
		  _configuracoes.GetConnectionString("BaseIndicadores"))) {
		return conexao.QueryFirstOrDefault<Jogador>(
			"SELECT Sigla, NomeIndicador, UltimaAtualizacao, Valor " +
			"FROM dbo.Jogadores " +
			"WHERE Sigla = @CodIndicador ",
			new { CodIndicador = codIndicador }
		);
	  }
	}

	public List<Jogador> ObterTodos() {
	  using (SqlConnection conexao = new SqlConnection(
		  _configuracoes.GetConnectionString("Futebol"))) {
		var list = conexao.GetAll<Jogador>();
		return list.AsList();
	  }
	}
  }
}