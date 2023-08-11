using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace db_auto_test.EFCore;

public partial class AutoContext : DbContext
{
    public AutoContext()
    {
    }

    public AutoContext(DbContextOptions<AutoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Efmigrationshistory> Efmigrationshistories { get; set; }

    public virtual DbSet<Twincategory> Twincategories { get; set; }

    public virtual DbSet<Twindatum> Twindata { get; set; }

    public virtual DbSet<Twingroup> Twingroups { get; set; }

    public virtual DbSet<Twinhistorydata> Twinhistorydatas { get; set; }

    public virtual DbSet<Twinhistorydatas20230808> Twinhistorydatas20230808s { get; set; }

    public virtual DbSet<Twinhistorydatas20230809> Twinhistorydatas20230809s { get; set; }

    public virtual DbSet<Twinhistorydatas20230810> Twinhistorydatas20230810s { get; set; }

    public virtual DbSet<Twinhistorydatatag> Twinhistorydatatags { get; set; }

    public virtual DbSet<Twinproject> Twinprojects { get; set; }

    public virtual DbSet<Twinprojectcatalog> Twinprojectcatalogs { get; set; }

    public virtual DbSet<Twinproperty> Twinproperties { get; set; }

    public virtual DbSet<Twintype> Twintypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("name=ConnectionStrings:DatabaseConnection", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Efmigrationshistory>(entity =>
        {
            entity.HasKey(e => e.MigrationId).HasName("PRIMARY");

            entity.ToTable("__efmigrationshistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

        modelBuilder.Entity<Twincategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("twincategory", tb => tb.HasComment("孪生体类别表"));

            entity.HasIndex(e => e.TwinGroupId, "IX_twinCategory_TwinGroup_Id");

            entity.Property(e => e.Id)
                .HasMaxLength(128)
                .HasComment("类别ID");
            entity.Property(e => e.GroupId)
                .HasMaxLength(128)
                .HasComment("组ID");
            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .HasComment("类别名称");
            entity.Property(e => e.TwinGroupId)
                .HasMaxLength(128)
                .HasColumnName("TwinGroup_Id");
            entity.Property(e => e.TypeId)
                .HasMaxLength(128)
                .HasComment("类型ID");

            entity.HasOne(d => d.TwinGroup).WithMany(p => p.Twincategories)
                .HasForeignKey(d => d.TwinGroupId)
                .HasConstraintName("FK_twinCategory_twinGroup_TwinGroup_Id");
        });

        modelBuilder.Entity<Twindatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("twindata", tb => tb.HasComment("孪生体数据表"));

            entity.HasIndex(e => e.TwinCategoryId, "IX_twinData_TwinCategory_Id");

            entity.Property(e => e.Id)
                .HasMaxLength(128)
                .HasComment("ID");
            entity.Property(e => e.CategoryId)
                .HasMaxLength(128)
                .HasComment("孪生体类别ID");
            entity.Property(e => e.ContentData)
                .HasComment("数据json")
                .HasColumnType("json");
            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .HasComment("孪生体类别名称");
            entity.Property(e => e.TwinCategoryId)
                .HasMaxLength(128)
                .HasColumnName("TwinCategory_Id");

            entity.HasOne(d => d.TwinCategory).WithMany(p => p.Twindata)
                .HasForeignKey(d => d.TwinCategoryId)
                .HasConstraintName("FK_twinData_twinCategory_TwinCategory_Id");
        });

        modelBuilder.Entity<Twingroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("twingroup", tb => tb.HasComment("孪生体组表"));

            entity.HasIndex(e => e.ProjectId1, "IX_twinGroup_Project_Id");

            entity.Property(e => e.Id)
                .HasMaxLength(128)
                .HasComment("分类ID");
            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .HasComment("分类名称");
            entity.Property(e => e.ProjectId)
                .HasMaxLength(128)
                .HasComment("所属项目ID")
                .HasColumnName("ProjectID");
            entity.Property(e => e.ProjectId1)
                .HasMaxLength(128)
                .HasColumnName("Project_Id");

            entity.HasOne(d => d.ProjectId1Navigation).WithMany(p => p.Twingroups)
                .HasForeignKey(d => d.ProjectId1)
                .HasConstraintName("FK_twinGroup_twinProject_Project_Id");
        });

        modelBuilder.Entity<Twinhistorydata>(entity =>
        {
            entity.HasKey(e => e.HistoryDataId).HasName("PRIMARY");

            entity.ToTable("twinhistorydatas", tb => tb.HasComment("回放数据表"));

            entity.Property(e => e.HistoryDataId)
                .HasMaxLength(128)
                .HasComment("数据id，主键");
            entity.Property(e => e.Extended)
                .HasComment("扩展字段，用于扩展字段历史的存储")
                .HasColumnType("json");
            entity.Property(e => e.GroupId)
                .HasMaxLength(128)
                .HasComment("批号，主键");
            entity.Property(e => e.Height).HasComment("高度");
            entity.Property(e => e.Latitude).HasComment("纬度");
            entity.Property(e => e.Longitude).HasComment("经度");
            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .HasComment("名称");
            entity.Property(e => e.Pitch).HasComment("俯仰");
            entity.Property(e => e.Roll).HasComment("翻滚");
            entity.Property(e => e.ScaleX).HasComment("缩放X");
            entity.Property(e => e.ScaleY).HasComment("缩放Y");
            entity.Property(e => e.ScaleZ).HasComment("缩放Z");
            entity.Property(e => e.TagId)
                .HasMaxLength(128)
                .HasComment("标签Id，与回放数据标签表关联");
            entity.Property(e => e.Time)
                .HasComment("时间（列名固定）")
                .HasColumnType("datetime");
            entity.Property(e => e.Yaw).HasComment("旋转");
        });

        modelBuilder.Entity<Twinhistorydatas20230808>(entity =>
        {
            entity.HasKey(e => e.HistoryDataId).HasName("PRIMARY");

            entity.ToTable("twinhistorydatas_20230808");

            entity.Property(e => e.HistoryDataId)
                .HasMaxLength(128)
                .HasComment("数据id，主键");
            entity.Property(e => e.Extended)
                .HasComment("扩展字段，用于扩展字段历史的存储")
                .HasColumnType("json");
            entity.Property(e => e.GroupId)
                .HasMaxLength(128)
                .HasComment("批号 主键");
            entity.Property(e => e.Height).HasComment("高度");
            entity.Property(e => e.Latitude).HasComment("纬度");
            entity.Property(e => e.Longitude).HasComment("经度");
            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .HasComment("名称");
            entity.Property(e => e.Pitch).HasComment("俯仰");
            entity.Property(e => e.Roll).HasComment("翻滚");
            entity.Property(e => e.ScaleX).HasComment("缩放X");
            entity.Property(e => e.ScaleY).HasComment("缩放Y");
            entity.Property(e => e.ScaleZ).HasComment("缩放Z");
            entity.Property(e => e.TagId)
                .HasMaxLength(128)
                .HasComment("标签Id，与回放数据标签表关联");
            entity.Property(e => e.Time)
                .HasComment("时间（列名固定）")
                .HasColumnType("datetime");
            entity.Property(e => e.Yaw).HasComment("旋转");
        });

        modelBuilder.Entity<Twinhistorydatas20230809>(entity =>
        {
            entity.HasKey(e => e.HistoryDataId).HasName("PRIMARY");

            entity.ToTable("twinhistorydatas_20230809");

            entity.Property(e => e.HistoryDataId)
                .HasMaxLength(128)
                .HasComment("数据id，主键");
            entity.Property(e => e.Extended)
                .HasComment("扩展字段，用于扩展字段历史的存储")
                .HasColumnType("json");
            entity.Property(e => e.GroupId)
                .HasMaxLength(128)
                .HasComment("批号 主键");
            entity.Property(e => e.Height).HasComment("高度");
            entity.Property(e => e.Latitude).HasComment("纬度");
            entity.Property(e => e.Longitude).HasComment("经度");
            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .HasComment("名称");
            entity.Property(e => e.Pitch).HasComment("俯仰");
            entity.Property(e => e.Roll).HasComment("翻滚");
            entity.Property(e => e.ScaleX).HasComment("缩放X");
            entity.Property(e => e.ScaleY).HasComment("缩放Y");
            entity.Property(e => e.ScaleZ).HasComment("缩放Z");
            entity.Property(e => e.TagId)
                .HasMaxLength(128)
                .HasComment("标签Id，与回放数据标签表关联");
            entity.Property(e => e.Time)
                .HasComment("时间（列名固定）")
                .HasColumnType("datetime");
            entity.Property(e => e.Yaw).HasComment("旋转");
        });

        modelBuilder.Entity<Twinhistorydatas20230810>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("twinhistorydatas_20230810");

            entity.Property(e => e.Id)
                .HasMaxLength(128)
                .HasComment("数据id，主键");
            entity.Property(e => e.Extended)
                .HasComment("扩展字段，用于扩展字段历史的存储")
                .HasColumnType("json");
            entity.Property(e => e.GroupId)
                .HasMaxLength(128)
                .HasComment("批号 主键");
            entity.Property(e => e.Height).HasComment("高度");
            entity.Property(e => e.Latitude).HasComment("纬度");
            entity.Property(e => e.Longitude).HasComment("经度");
            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .HasComment("名称");
            entity.Property(e => e.Pitch).HasComment("俯仰");
            entity.Property(e => e.Roll).HasComment("翻滚");
            entity.Property(e => e.ScaleX).HasComment("缩放X");
            entity.Property(e => e.ScaleY).HasComment("缩放Y");
            entity.Property(e => e.ScaleZ).HasComment("缩放Z");
            entity.Property(e => e.TagId)
                .HasMaxLength(128)
                .HasComment("标签Id，与回放数据标签表关联");
            entity.Property(e => e.Time)
                .HasComment("时间（列名固定）")
                .HasColumnType("datetime");
            entity.Property(e => e.Yaw).HasComment("旋转");
        });

        modelBuilder.Entity<Twinhistorydatatag>(entity =>
        {
            entity.HasKey(e => e.TagDataId).HasName("PRIMARY");

            entity.ToTable("twinhistorydatatag", tb => tb.HasComment("回放数据标签表"));

            entity.Property(e => e.TagDataId)
                .HasMaxLength(128)
                .HasComment("ID");
            entity.Property(e => e.Count).HasComment("历史数据条数");
            entity.Property(e => e.GrouId)
                .HasMaxLength(128)
                .HasComment("批号");
            entity.Property(e => e.MaxTime)
                .HasComment("最大时间值")
                .HasColumnType("datetime");
            entity.Property(e => e.MinTime)
                .HasComment("最小时间值")
                .HasColumnType("datetime");
            entity.Property(e => e.Remark)
                .HasMaxLength(128)
                .HasComment("备注，预留字段");
            entity.Property(e => e.Tag)
                .HasMaxLength(128)
                .HasComment("标签");
            entity.Property(e => e.TagId)
                .HasMaxLength(128)
                .HasComment("标签id，与回放数据关联");
        });

        modelBuilder.Entity<Twinproject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("twinproject", tb => tb.HasComment("项目结构表"));

            entity.HasIndex(e => e.ProjectCategoryId, "IX_twinProject_ProjectCategory_Id");

            entity.Property(e => e.Id)
                .HasMaxLength(128)
                .HasComment("项目ID");
            entity.Property(e => e.CategoryId)
                .HasMaxLength(128)
                .HasComment("项目类别ID");
            entity.Property(e => e.CimserverUrl)
                .HasMaxLength(128)
                .HasComment("CIMServerUrl地址")
                .HasColumnName("CIMServerUrl");
            entity.Property(e => e.EnName)
                .HasMaxLength(128)
                .HasComment("英文名称");
            entity.Property(e => e.ExpTime).HasComment("到期时间");
            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .HasComment("项目名称");
            entity.Property(e => e.Price)
                .HasComment("发布价格")
                .HasColumnType("double(10,2)");
            entity.Property(e => e.ProjectCategoryId)
                .HasMaxLength(128)
                .HasColumnName("ProjectCategory_Id");
            entity.Property(e => e.PublishTime).HasComment("发布时间");
            entity.Property(e => e.PublishUrl)
                .HasMaxLength(128)
                .HasComment("发布地址");
            entity.Property(e => e.Status).HasComment("审核状态 0-已通过 1 未通过");
            entity.Property(e => e.Visits).HasComment("总调用次数");
            entity.Property(e => e.VisitsOfToday).HasComment("今日调用次数");

            entity.HasOne(d => d.ProjectCategory).WithMany(p => p.Twinprojects)
                .HasForeignKey(d => d.ProjectCategoryId)
                .HasConstraintName("FK_twinProject_twinProjectCatalog_ProjectCategory_Id");
        });

        modelBuilder.Entity<Twinprojectcatalog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("twinprojectcatalog", tb => tb.HasComment("类别结构表"));

            entity.Property(e => e.Id)
                .HasMaxLength(128)
                .HasComment("类别ID");
            entity.Property(e => e.CreateBy)
                .HasMaxLength(128)
                .HasComment("创建用户ID");
            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .HasComment("类别名称");
            entity.Property(e => e.ParentId)
                .HasMaxLength(128)
                .HasComment("父级Id");
        });

        modelBuilder.Entity<Twinproperty>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("twinproperty", tb => tb.HasComment("孪生体属性表"));

            entity.HasIndex(e => e.TwinCategoryId, "IX_twinProperty_TwinCategory_Id");

            entity.Property(e => e.Id)
                .HasMaxLength(128)
                .HasComment("ID");
            entity.Property(e => e.CategoryId)
                .HasMaxLength(128)
                .HasComment("孪生体类别ID");
            entity.Property(e => e.ContentData)
                .HasComment("数据json")
                .HasColumnType("json");
            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .HasComment("孪生体类别名称");
            entity.Property(e => e.SortIndex).HasComment("属性排序");
            entity.Property(e => e.TwinCategoryId)
                .HasMaxLength(128)
                .HasColumnName("TwinCategory_Id");

            entity.HasOne(d => d.TwinCategory).WithMany(p => p.Twinproperties)
                .HasForeignKey(d => d.TwinCategoryId)
                .HasConstraintName("FK_twinProperty_twinCategory_TwinCategory_Id");
        });

        modelBuilder.Entity<Twintype>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("twintype", tb => tb.HasComment("孪生体类型表"));

            entity.Property(e => e.Id)
                .HasMaxLength(128)
                .HasComment("ID");
            entity.Property(e => e.ContentData)
                .HasComment("属性定义")
                .HasColumnType("json");
            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .HasComment("类型名称");
            entity.Property(e => e.SortIndex).HasComment("排序值");
            entity.Property(e => e.TypeId)
                .HasMaxLength(128)
                .HasComment("类型Id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
