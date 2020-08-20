using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace DevBoost.ORM.Models {

  [Table("dbo.Clube")]
  public class Clube {

	[ExplicitKey]
	public string Nome { get; set; }
	public string Divisao { get; set; }
  }
}
