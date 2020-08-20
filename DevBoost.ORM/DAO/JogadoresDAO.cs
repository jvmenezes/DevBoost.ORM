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

	public IEnumerable<Jogador> ObterTodos() {
	  using (SqlConnection conexao = new SqlConnection(
		  _configuracoes.GetConnectionString("Futebol"))) {
		return conexao.Query<Jogador, Posicao, Clube, Jogador>(			
			"SELECT * " +
			"FROM Dbo.Jogador J " +
			"INNER JOIN Dbo.Posicao P ON J.IDPosicao = P.IDPosicao " +
			"INNER JOIN Dbo.Clube C ON J.IDClube = C.IDClube ",
			  map: (jogador, posicao, clube) => {
				jogador.Posicao = posicao;
				jogador.Clube = clube;
				;				
				return jogador;
			  },
						  splitOn: "CPF,IDPosicao, IDClube"
		);
	  }
	}
	
  }
}