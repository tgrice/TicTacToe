using System.Collections.Generic;
using System.Web.Http;

namespace TTT_WebAPI.Controllers
{
    public class TicTacToeController : ApiController
    {
        // GET api/<controller>
        // GET api/tictactoe
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "id equals " + id;
        }

        //[HttpPost]
        //public OutgoingGameInformation CreateGame()
        //{

        //}

        //[HttpPost]
        //public OutgoingGameInformation PlayTurn(IncomingTurnInformation turn)
        //{
        //    // examine / validate incoming turn information
        //    // apply the turn to the engine / controller
        //    // package up the outcome of the turn
        //    // return the outcome information back to the client

        //}

        // POST api/<controller>
        public string Post([FromBody]string value)
        {
            return "value equals " + value;
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}