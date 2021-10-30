using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Alcoholemia.Api.Domain;
using Microsoft.Extensions.Logging;


/*Nombre de la escuela: Universidad Tecnologica Metropolitana
Asignatura: Aplicaciones Web Orientadas a Servicios
Nombre del Maestro: Chuc Uc Joel Ivan
Nombre de la actividad: Actividad 2
Nombre del alumno: Avila Ramayo Brandon Jefte
Cuatrimestre: 4
Grupo: B
Parcial: 2
*/

namespace Alcoholemia.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlcoholemiaController : ControllerBase
    {

        [HttpGet]
        [Route("GetCalculate")]
        
        public IActionResult Calculo(string trago, int CantidadDeTragos, int peso)
        {
            var Texto = "";

            Tragos bebida = new Tragos();
            bebida.Bebida = trago;
            switch(bebida.Bebida){
                case "Cerveza":
                    bebida.Mililitros = 330;
                    bebida.Grados = 0.05;
                break;
                    case "Vino":
                    bebida.Mililitros = 100;
                    bebida.Grados = 0.12;
                break;
                    case "Vermú":
                    bebida.Mililitros = 70;
                    bebida.Grados = 0.17;
                break;
                    case "Licor":
                    bebida.Mililitros = 45;
                    bebida.Grados = 0.23;
                break;
                    case "Brandy":
                    bebida.Mililitros = 45;
                    bebida.Grados = 0.38;
                break;
                    case "Combinado":
                    bebida.Mililitros = 50;
                    bebida.Grados = 0.38;
                break;
                default:
                    Texto = ($"La bebida es: {trago} ");
                    return Ok(Texto);

            }

            double Totally = (bebida.Mililitros * CantidadDeTragos);
            double TragosConsumidos = bebida.Grados * Totally;
            double Sangre = 0.15 * TragosConsumidos;
            double Ethanol = 0.789 * Sangre;
            double Pesokg = 0.08 * peso;
            double Alcoholemia = Ethanol / Pesokg;

            if (Alcoholemia > 0.8)
            {
                Texto = ($"Su cantidad de alcohol en la sangre es: {Alcoholemia.ToString("##,##0.00000")}, debe de solicitar apoyo de un conductor sobrio");
            }
            else
            {
                Texto = ($"¡Todo correcto, tenga un excelente viaje!");
            }

            return Ok(Texto);

        }
    }
}
