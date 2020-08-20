using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevBoost.ORM.DAO;
using DevBoost.ORM.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevBoost.ORM.Controllers {
  [Route("api/[controller]")]
  public class FutebolController : Controller {
	
	[HttpGet("jogadores")]
	public ActionResult<List<Jogador>> GetAllJogadores([FromServices]JogadoresDAO jogadoresDAO) { //Com o FromServices vc consegue injetar a classe JogadoresDAO diretamente, isso serve se vc for usar apenas em uma ActionResult
	  var result = jogadoresDAO.ObterTodos();
	  return result.ToList();
	}

	[HttpGet("clubes")]
	public ActionResult<List<Clube>> GetAllClubes([FromServices]ClubesDAO clubesDAO) { //Com o FromServices vc consegue injetar a classe JogadoresDAO diretamente, isso serve se vc for usar apenas em uma ActionResult
	  var result = clubesDAO.ObterTodos();
	  return result.ToList();
	}

	[HttpGet("posicoes")]
	public ActionResult<List<Posicao>> GetAllPosicoes([FromServices]PosicoesDAO posicoesDAO) { //Com o FromServices vc consegue injetar a classe JogadoresDAO diretamente, isso serve se vc for usar apenas em uma ActionResult
	  var result = posicoesDAO.ObterTodos();
	  return result.ToList();
	}
  }
}