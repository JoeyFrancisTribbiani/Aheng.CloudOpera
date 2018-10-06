using System;
using System.Collections.Generic;
using System.Text;

namespace Aheng.CloudOpera.Core.Entities
{
    public class UserRelationship
    {
        public Guid Id { get; set; }
        /// <summary>
        /// 被关注人的id
        /// </summary>
        public Guid IdolId{ get; set; }
        /// <summary>
        /// 粉丝的id
        /// </summary>
        public Guid FanId { get; set; }
        /// <summary>
        /// 关注事件发生的时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
