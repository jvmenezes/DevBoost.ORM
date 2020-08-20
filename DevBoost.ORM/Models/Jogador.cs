using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace DevBoost.ORM.Models {

  [Table("dbo.Jogador")]
  public class Jogador {

	[ExplicitKey]
	public string CPF { get; set; }
	public string Nome { get; set; }
	public string Posicao { get; set; }
	public string Clube { get; set; }
  }
}
