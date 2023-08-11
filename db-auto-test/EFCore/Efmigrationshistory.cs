using System;
using System.Collections.Generic;

namespace db_auto_test.EFCore;

public partial class Efmigrationshistory
{
    public string MigrationId { get; set; } = null!;

    public string ProductVersion { get; set; } = null!;
}
