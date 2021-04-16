using GestioneOrdini.BusinessLayer;
using GestioneOrdini.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestioneOrdini.RestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GestioneOrdiniController : ControllerBase
    {
        //uso la classe BusinessLayer
        private readonly IOrderBL bl;
        public GestioneOrdiniController(IOrderBL bl)
        {
            this.bl = bl;
        }

        //client get by id
        [HttpGet("client/{id}")]
        public ActionResult GetClientById(int id)
        {
            var client = bl.GetClient(id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }
        //order get by id
        [HttpGet("order/{id}")]
        public ActionResult GetOrderById(int id)
        {
            var order = bl.GetOrder(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }


        //delete client
        [HttpDelete("client/{id}")]
        public ActionResult DeleteClient(int id)
        {
            var client = bl.GetClient(id);
            if (client == null)
            {
                return NotFound();
            }
            //elimino
            bl.DeleteClient(id);

            return Ok();
        }
        //delete order
        [HttpDelete("order/{id}")]
        public ActionResult DeleteOrder(int id)
        {
            var order = bl.GetOrder(id);
            if (order == null)
            {
                return NotFound();
            }
            //elimino
            bl.DeleteOrder(id);

            return Ok();
        }


        //create client
        [HttpPost("client/")]
        public ActionResult CreateClient([FromBody] Client client)
        {
            if (client == null)
            {
                return BadRequest();
            }

            bool ok = bl.CreateClient(client);
            if (ok)
            {
                return Created($"{HttpContext.Request.Path}/{client.ID}", client);
            }
            return BadRequest();
            
        }
        //create order
        [HttpPost("order/{idClient}")]
        public ActionResult CreateOrder([FromBody] Order order, int idClient)
        {
            if (order == null)
            {
                return BadRequest();
            }
            var client = bl.GetClient(idClient);
            if(client == null)
            {
                return BadRequest();
            }
            order.IDCustomer = idClient;
            bool ok = bl.CreateOrder(order);
            if (ok)
            {
                return Created($"{HttpContext.Request.Path}/{order.ID}", order);
            }
            return BadRequest();
            
        }


        //update client
        [HttpPut("client/{id}")]
        public ActionResult UpdateClient(Client client, int id)
        {
            if (client == null)
            {
                return BadRequest();
            }

            bl.UpdateClient(client, id);
            return Ok();
        }
        //update order
        [HttpPut("order/{id}")]
        public ActionResult UpdateOrder(Order order, int id)
        {
            if (order == null)
            {
                return BadRequest();
            }

            bl.UpdateOrder(order, id);
            return Ok();
        }
    }
}
