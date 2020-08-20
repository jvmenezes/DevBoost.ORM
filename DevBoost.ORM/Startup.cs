using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevBoost.ORM.DAO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DevBoost.ORM {
  public class Startup {
	public Startup(IConfiguration configuration) {
	  Configuration = configuration;
	}

	public IConfiguration Configuration { get; }

	// This method gets called by the runtime. Use this method to add services to the container.
	public void ConfigureServices(IServiceCollection services) {

	  /* Fazendo a injeção de dependência das implentações dessas interfaces */
	  services.AddSingleton<IConfiguration>(_ => Configuration); //Cria uma única instância, pois não tem problema utilizar o mesmo objeto para todas as requisições nesse caso
	  services.AddTransient<JogadoresDAO>(); //Transiente faz com que seja criado um objeto para cada requisição realizada para essa interface, afim de evitar concorrência
	  services.AddTransient<PosicoesDAO>(); //Transiente faz com que seja criado um objeto para cada requisição realizada para essa interface, afim de evitar concorrência
	  services.AddTransient<ClubesDAO>(); //Transiente faz com que seja criado um objeto para cada requisição realizada para essa interface, afim de evitar concorrência

	  services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
	}

	// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
	public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
	  if (env.IsDevelopment()) {
		app.UseDeveloperExceptionPage();
	  }

	  app.UseMvc();
	}
  }
}
