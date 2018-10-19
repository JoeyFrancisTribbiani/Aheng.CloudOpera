using System;
using System.Collections.Generic;
using System.Text;

namespace Aheng.CloudOpera.Core.Entities
{
    public class VedioFile
    {
        #region 视频上传
        public Guid UploadId { get; set; }
        public Guid VedioId { get; set; }
        public string Uri { get; set; }
        public int Position { get; set; }
        public decimal Size { get; set; }
        #endregion
    }
}
