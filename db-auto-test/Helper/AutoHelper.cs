using db_auto_test.EFCore;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

namespace DBAuto.Helper
{
    public static class AutoHelper
    {
        public static void AutoInsert(DbContext context)
        {
            string tableName = "YourTableName";
            var entityType = context.Model.FindEntityType(tableName);

            if (entityType != null)
            {
                // Get the CLR type associated with the table
                var entityTypeClrType = entityType.ClrType;

                // Check if the CLR type is a valid entity type
                if (entityTypeClrType != null && entityTypeClrType.IsClass && !entityTypeClrType.IsAbstract && entityTypeClrType.GetConstructor(Type.EmptyTypes) != null)
                {
                    // Create an instance of the entity and populate its properties with data
                    var entity = Activator.CreateInstance(entityTypeClrType);
                    // Set property values accordingly

                    // Add the entity to the context and save changes
                    context.Add(entity);
                    context.SaveChanges();

                    Console.WriteLine("Data inserted successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid entity type for the specified table name.");
                }
            }
            else
            {
                Console.WriteLine("Table not found in the database.");
            }
        }

        #region 分表创建方法以及插入数据方法
        /// <summary>
        /// 根据天创建分表的方法 不存在就创建 存在就跳出
        /// </summary>
        /// <param name="time"></param>
        public static void CreateTableIfNotExists(DbContext dbContext, string tableName)
        {

            string createTableSql = $@"
                CREATE TABLE IF NOT EXISTS {tableName}
                (
                   `HistoryDataId` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '数据id，主键',
                   `GroupId` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '批号 主键',
                   `Name` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '名称',
                   `Longitude` double NOT NULL COMMENT '经度',
                   `Latitude` double NOT NULL COMMENT '纬度',
                   `Height` double NOT NULL COMMENT '高度',
                   `Yaw` float NOT NULL COMMENT '旋转',
                   `Pitch` float NOT NULL COMMENT '俯仰',
                   `Roll` float NOT NULL COMMENT '翻滚',
                   `ScaleX` float NOT NULL COMMENT '缩放X',
                   `ScaleY` float NOT NULL COMMENT '缩放Y',
                   `ScaleZ` float NOT NULL COMMENT '缩放Z',
                   `Time` datetime(0) NOT NULL COMMENT '时间（列名固定）',
                   `TagId` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '标签Id，与回放数据标签表关联',
                   `Extended` json  COMMENT '扩展字段，用于扩展字段历史的存储',
                    PRIMARY KEY (`HistoryDataId`) USING BTREE
                )";

            dbContext.Database.ExecuteSqlRaw(createTableSql);
            dbContext.SaveChanges();
        }
        /// <summary>
        /// 插入分表数据的方法 插入前先根据批号和标签id进行判断数据是否存在 存在就覆盖原数据 不存在就新增一条数据
        /// </summary>
        /// <param name="twinHistoryDatas"></param>
        /// <returns></returns>

        public static int InsertDataToFenBiao(DbContext dbContext, Twinhistorydata twinHistoryDatas)
        {
            string tableName = $"twinHistoryDatas_{twinHistoryDatas.Time:yyyyMMdd}";

            CreateTableIfNotExists(dbContext, tableName);

            #region 添加所需参数
            var parameters = new MySqlParameter[]
                        {
                new MySqlParameter("@HistoryDataId", twinHistoryDatas.HistoryDataId),
                new MySqlParameter("@GroupId", twinHistoryDatas.GroupId),
                new MySqlParameter("@Name", twinHistoryDatas.Name),
                new MySqlParameter("@Longitude", twinHistoryDatas.Longitude),
                new MySqlParameter("@Latitude", twinHistoryDatas.Latitude),
                new MySqlParameter("@Height", twinHistoryDatas.Height),
                new MySqlParameter("@Yaw", twinHistoryDatas.Yaw),
                new MySqlParameter("@Pitch", twinHistoryDatas.Pitch),
                new MySqlParameter("@Roll", twinHistoryDatas.Roll),
                new MySqlParameter("@ScaleX", twinHistoryDatas.ScaleX),
                new MySqlParameter("@ScaleY", twinHistoryDatas.ScaleY),
                new MySqlParameter("@ScaleZ", twinHistoryDatas.ScaleY),
                new MySqlParameter("@Time", twinHistoryDatas.Time),
                new MySqlParameter("@TagId", twinHistoryDatas.TagId),
                new MySqlParameter("@Extended", twinHistoryDatas.Extended),
                        };
            #endregion

            //插入之前添加判断 tagId或groupid是否已经存在是否已经存在 如果存在 更新数据时覆盖原数据
            string where = String.Empty;
            if (twinHistoryDatas.GroupId != null)
            {
                where += $" WHERE GroupId = '{twinHistoryDatas.GroupId}'";
            }
            if (twinHistoryDatas.TagId != null)
            {
                where += $" AND TagId = '{twinHistoryDatas.TagId}'";
            }
            return dbContext.Database.ExecuteSqlRaw($"INSERT INTO `{tableName}` (HistoryDataId, GroupId, Name, Longitude,Latitude,Height,Yaw,Pitch,Roll,ScaleX,ScaleY,ScaleZ,Time,TagId,Extended) VALUES (@HistoryDataId, @GroupId, @Name, @Longitude,@Latitude,@Height,@Yaw,@Pitch,@Roll,@ScaleX,@ScaleY,@ScaleZ,@Time,@TagId,@Extended)", parameters);
        }

        #endregion
    }
}