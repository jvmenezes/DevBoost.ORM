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

	public List<Clube> ObterTodos() {
	  using (SqlConnection conexao = new SqlConnection(
		  _configuracoes.GetConnectionString("Futebol"))) {
		var list = conexao.GetAll<Clube>();
		return list.AsList();
	  }
	}
  }
}