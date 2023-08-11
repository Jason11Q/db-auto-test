using db_auto_test.Dto;
using db_auto_test.EFCore;
using DBAuto.Helper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace db_auto_test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutoController : ControllerBase
    {

        private readonly AutoContext _autoContext;
        public AutoController(AutoContext autoContext)
        {
            _autoContext = autoContext;
        }


        /// <summary>
        /// 批量生成分表数据
        /// </summary>
        /// <param name="fbDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/historyData/generate")]
        [Consumes("application/json")]
        [SwaggerOperation("批量生成分表数据")]
        public async Task<IActionResult> GenerateHistoryDataAsync([FromBody] GenerateHistoryRequest request)
        {
            DateTime date = request.StartTime.Date;
            int count = (int)Math.Ceiling(24 * 60 * 60 * 1.0 / request.Interval);

            if (request.DayCount < count)
            {
                count = request.DayCount;
            }

            string tagId = Nanoid.Nanoid.Generate(size: 16).ToString();
            string groupId = $"{date:yyyMMdd}";

            Twinhistorydatatag dataTag = new Twinhistorydatatag()
            {
                TagDataId = Nanoid.Nanoid.Generate(size: 16).ToString(),
                TagId = tagId,
                Tag = "AutoGenerate",
                GrouId = groupId,
                MaxTime = date,
                MinTime = date,
                Count = count,
            };

            await _autoContext.Twinhistorydatatags.AddAsync(dataTag);

            for (int i = 0; i < request.Days; i++)
            {

                for (int j = 0; j < count; j++)
                {
                    Twinhistorydata data = new Twinhistorydata()
                    {
                        HistoryDataId = Nanoid.Nanoid.Generate(size: 16).ToString(),
                        GroupId = groupId,
                        Name = "测试数据",
                        Time = date,
                        TagId = tagId
                    };

                    AutoHelper.InsertDataToFenBiao(_autoContext, data);

                    date = date.AddSeconds(request.Interval);
                }

                // 每天重置时间
                date = date.Date;
                date = date.AddDays(1);
            }

            await _autoContext.SaveChangesAsync();

            return Ok();
        }


    }
}
