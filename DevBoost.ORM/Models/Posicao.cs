using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace DevBoost.ORM.Models {

  [Table("dbo.Posicao")]
  public class Posicao {

	[ExplicitKey]
	public int IDPosicao { get; set; }
	public string Descricao { get; set; }
  }
}
