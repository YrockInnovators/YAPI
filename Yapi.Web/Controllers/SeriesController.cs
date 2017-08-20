using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Yapi.Web.Controllers
{
    public class SeriesController : ApiController
    {
        /// <summary>
        /// Get all serieses available
        /// </summary>
        /// <returns></returns>
        public async Task<IHttpActionResult> Get()
        {
            var blogCategory = Convert.ToInt16(ConfigurationManager.AppSettings["blogCategory"]);

            var context = new EF.YapiContext();
            var serieses = await context.pages.Where(x => x.parent_id == blogCategory).ToListAsync();

            var list = new List<Models.Series>();

            foreach (var series in serieses)
            {
                var _sermons = await context.pages.Where(x => x.parent_id == series.id).CountAsync();
                var _title = await context.field_title.FirstOrDefaultAsync(x => x.pages_id == series.id);
                var _date = await context.field_series_date_start.FirstOrDefaultAsync(x => x.pages_id == series.id);

                var obj = new Models.Series
                {
                    Id = series.id,
                    Sermons = _sermons,
                    Title = _title == null ? "" : _title.data,
                    Date = _date == null ? Convert.ToDateTime(null) : _date.data
                };

                list.Add(obj);
            }

            return Json(list.OrderByDescending(x => x.Date).Take(5));
        }

        /// <summary>
        /// Gets the sermon-summaries from series
        /// </summary>
        /// <param name="id">series id</param>
        /// <returns></returns>
        public async Task<IHttpActionResult> Get(long id)
        {
            var context = new EF.YapiContext();

            var list = new List<Models.SermonSumary>();

            var sermons = await context.pages.Where(x => x.parent_id == id).ToListAsync();

            foreach (var sermon in sermons)
            {
                var _series = await context.field_title.FirstOrDefaultAsync(x => x.pages_id == id);
                var _title = await context.field_title.FirstOrDefaultAsync(x => x.pages_id == sermon.id);
                var _date = await context.field_media_date.FirstOrDefaultAsync(x => x.pages_id == sermon.id);

                var obj = new Models.SermonSumary
                {
                    Id = sermon.id,
                    Series = _series == null ? "" : _series.data,
                    Title = _title == null ? "" : _title.data,
                    Date = _date == null ? Convert.ToDateTime(null) : _date.data
                };

                list.Add(obj);
            }

            return Json(list.OrderByDescending(x => x.Date));
        }
    }
}
