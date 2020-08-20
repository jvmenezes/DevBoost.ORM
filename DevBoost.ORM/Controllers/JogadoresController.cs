using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevBoost.ORM.DAO;
using DevBoost.ORM.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevBoost.ORM.Controllers {
  [Route("api/[controller]")]
  public class JogadoresController : Controller {
	
	[HttpGet("")]
	public ActionResult<List<Jogador>> GetAll([FromServices]JogadoresDAO indicadoresDAO) { //Com o FromServices vc consegue injetar a classe JogadoresDAO diretamente, isso serve se vc for usar apenas em uma ActionResult
	  var indicadores = indicadoresDAO.ObterTodos();
	  return indicadores;
	}

	//http://localhost:60669/api/indicadores/salario
	[HttpGet("{id}")]
	public ActionResult<Jogador> Get([FromServices]JogadoresDAO indicadoresDAO, string id) { //Com o FromServices vc consegue injetar a classe JogadoresDAO diretamente, isso serve se vc for usar apenas em uma ActionResult
	  var indicadores = indicadoresDAO.ObterUmQueryDynamic(id);
	  return indicadores;
	}
  }
}