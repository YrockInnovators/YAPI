using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Yapi.Web.Controllers
{
    public class SermonController : ApiController
    {
        /// <summary>
        /// Displays the sermon detail from sermon id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IHttpActionResult> Get(long id)
        {
            var context = new EF.YapiContext();            
                
            var _title = await context.field_title.FirstOrDefaultAsync(x => x.pages_id == id);
            var _date = await context.field_media_date.FirstOrDefaultAsync(x => x.pages_id == id);
            var _body = await context.field_body.FirstOrDefaultAsync(x => x.pages_id == id);

            var obj = new Models.SermonDetail
            {                   
                Title = _title == null ? "" : _title.data,
                Date = _date == null ? Convert.ToDateTime(null) : _date.data,
                Body = _body == null ? "" : _body.data
            };

            return Json(obj);
        }
    }
}
