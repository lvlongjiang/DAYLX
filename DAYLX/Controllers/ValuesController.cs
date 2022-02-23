using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication21.Controllers;

namespace DAYLX.Controllers
{
    [ApiController]
    public class ValuesController : BaseController
    {
     
        public ValuesController(IConfiguration configuration) : base(configuration)
        {

        }


        [HttpPost]
        [Route("api/StartLeave")]
        public void StartLeave(Leave leave)
        {
            //发起流程
            StartProccess<Leave>(leave);
        }

    }
}
