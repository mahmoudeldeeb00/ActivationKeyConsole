using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivationKeyConsole.Domain
{
    public class AppSettingClass
    {
        public string? SystemAllowedDevices { get; set; } = "Device1,Device2";
        public string? SystemExpireDate { get; set; } = "3000-01-01";
        public int MaximumNumberOfUsers { get; set; } = 2;
        public int ServerTimeDifference { get; set; } = 0;
        public int UtaTimeDifference { get; set; } = -2;
        public int JWTExpiredTimeInHour { get; set; } = 24;
        public string? ReceiptFooterHeader { get; set; } = "تم التطوير بواسطة بيزنس ايكو سيستم";
    //        "ReceiptFooterHeader": "ggXg4VvMVpchpsCEIQQ/klG9fKdrqKeWKyLXeljWW352XY2Wm03SrK5gCgvB4uxSO6xRoC3qnErgy4svAPlreA==",
    //"ServerTimeDifference": "gSMYD4KNm+47BcbqJQe9gQ==",
    //"UtaTimeDifference": "Lxarg25JRLCoLR5PlsUdfQ==",
    //"JWTExpiredTimeInHour": "1ep0EmHvGx7juhpJTotbjA==",
    //"MaximumNumberOfUsers": "gSMYD4KNm+47BcbqJQe9gQ==",
    //"SystemExpireDate": "EIyMjLx0jyWabtP6TXlXzw==",
    //"SystemAllowedDevices": "ZnTwS15Og2NI86Te4VXLiZLF4XPgPP6sZvAr8/mXV73zIpsxN3wHOB+6eUGwzq0/J3mqFVPUjeDAk0PWyRGT6PR0tM0QkUj4KzKRJKC5czE="
    }
}
